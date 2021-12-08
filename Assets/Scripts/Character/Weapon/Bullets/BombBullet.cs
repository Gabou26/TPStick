using System.Collections;
using UnityEngine;

public class BombBullet : BaseBullet
{
    //Explosion
    public ParticleSystem explosion;
    public float explosionRadius = 8;


    private void Start()
    {
       // print("OK : " + transform.r);
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.velocity = new Vector3();
        rigid.AddForce(transform.forward * vitesse);
    }

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
    }

    void Explode()
    {
        if (isDestroying)
            return;

        isDestroying = true;
        Collider[] targets = Physics.OverlapSphere(transform.position, explosionRadius, playerTrigger);
        foreach (var target in targets)
        {
            if (target.GetType() != typeof(CharacterController)) {
                continue;
            }

            if (target.isTrigger)
                continue;

            float w = 1-Vector3.Distance(transform.position,target.transform.position)/explosionRadius;
            float x = Mathf.Max(w, .2f);

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
                        point.AddForce(dir * 10 * weaponDamage * x + new Vector3(0,-100,0), ForceMode.Impulse);
                    }
                }
                else
                {
                    if (player.activeSelf && bar)
                    {
                        bar.TakeDamage(player, weaponDamage * x);
                    }
                }
            }
        }
        StartCoroutine(Exploser());
    }

    IEnumerator Exploser()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
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
