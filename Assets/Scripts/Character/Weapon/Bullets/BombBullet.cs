using System.Collections;
using System.Collections.Generic;
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
        RaycastHit[] targets = Physics.SphereCastAll(transform.position, explosionRadius, transform.forward, playerTrigger);
        foreach (var target in targets)
        {
           // target.transform.GetComponent<ScoreManager>().SetLastShooter(player);
            HealthBar bar = target.transform.GetComponent<HealthBar>();
            print("TARGER");
            if (player.activeSelf && bar)
                bar.TakeDamage(player, weaponDamage);
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

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
