using System.Collections;
using System.Collections.Generic;
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
        RaycastHit[] targets = Physics.SphereCastAll(transform.position, explosionRadius, Vector3.zero, playerTrigger);
        foreach (var target in targets)
        {
            target.transform.GetComponentInParent<ScoreManager>().SetLastShooter(player);
            HealthBar bar = target.transform.GetComponent<HealthBar>();
            if (player.activeSelf && bar)
                bar.TakeDamage(player, weaponDamage);
        }
        StartCoroutine(Exploser());
    }

    IEnumerator Exploser()
    {
        GetComponent<MeshRenderer>().enabled = false;
        //explosif.GetComponent<AudioSource>().Stop();
        explosion.Play();

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
