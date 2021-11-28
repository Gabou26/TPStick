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
        rigid.AddForce(Vector3.forward * vitesse);
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
