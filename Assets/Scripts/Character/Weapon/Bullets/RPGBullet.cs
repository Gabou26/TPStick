using System.Collections;
using UnityEngine;

public class RPGBullet : BaseBullet
{
    //Explosion
    public ParticleSystem explosion;
    public float explosionRadius = 8;
    public LayerMask explosionTrigger;

    private void Start()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position - transform.forward, transform.forward, out hit, 2f, explosionTrigger))
        {
            transform.position -= transform.forward;
            transform.position += transform.forward * hit.distance;
            Explode();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroying)
            return;

        currLength += Time.deltaTime;
        if (currLength >= lifeLength)
        {
            Explode();
            return;
        }
        float vitDelta = vitesse * Time.deltaTime;


        transform.Translate(Vector3.forward * vitDelta);

        VerifColl(vitDelta);
    }

    void VerifColl(float checkDist)
    {
        //Verif collision
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, checkDist, explosionTrigger))
        {
            transform.position += transform.forward * hit.distance;
            Explode();
        }
    }

    void Explode()
    {
        if (isDestroying)
            return;

        isDestroying = true;
        Collider[] targets = Physics.OverlapSphere(transform.position, explosionRadius, playerTrigger);
        foreach (var target in targets)
        {
            if (target.isTrigger)
                continue;

            // target.transform.GetComponent<ScoreManager>().SetLastShooter(player);
            HealthBar bar = target.transform.GetComponent<HealthBar>();
            if (player.activeSelf && bar)
            {
                Third_person_mvmnt hitplayer = bar.gameObject.GetComponent<Third_person_mvmnt>();
                if (hitplayer.dead)
                {
                    Vector3 dir = bar.gameObject.transform.position - transform.position;
                    Rigidbody point = hitplayer.spine.GetComponent<Rigidbody>();
                    if (point != null)
                    {
                        point.AddForce(dir * 500, ForceMode.Impulse);
                    }
                }
                else
                {
                    if (player.activeSelf && bar)
                    {
                        bar.TakeDamage(player, weaponDamage);
                    }
                }
            }
        }
        StartCoroutine(Exploser());
    }

    IEnumerator Exploser()
    {
        GetComponent<MeshRenderer>().enabled = false;
        //explosif.GetComponent<AudioSource>().Stop();
        explosion.Play();
        explosion.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
