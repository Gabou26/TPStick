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
        Collider[] targets = Physics.OverlapSphere(transform.position, explosionRadius, playerTrigger);
        foreach (var target in targets)
        {
            if (target.isTrigger)
                continue;

           // target.transform.GetComponent<ScoreManager>().SetLastShooter(player);
            HealthBar bar = target.transform.GetComponent<HealthBar>();
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
