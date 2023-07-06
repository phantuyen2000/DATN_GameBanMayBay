using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    float shotCounter;
    float minDelay;
    float maxDelay;
    float shootSoundVolume;
    AudioClip shootSound;
    GameObject projectile;
    void Start()
    {
        shootSound = GetComponent<Enemy>().GetShootSound();
        projectile = GetComponent<Enemy>().GetProjectile();
        shootSoundVolume = GetComponent<Enemy>().GetShootSoundVolume();
        minDelay = GetComponent<Enemy>().GetMinShootDelay();
        maxDelay = GetComponent<Enemy>().GetMaxShootDelay();
        shotCounter = Random.Range(minDelay, maxDelay);
    }
    void Update()
    {
        CountDownAndShoot();
    }
    private void CountDownAndShoot()
    {
        
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minDelay, maxDelay);
        }
    }

    private void Fire()
    {
        Vector2 v1 = new Vector2(transform.position.x + 0.2f, transform.position.y);
        Vector2 v2 = new Vector2(transform.position.x - 0.2f, transform.position.y);
        GameObject laser1 = Instantiate(projectile, v1, Quaternion.Euler(new Vector3(0, 0, 14))) as GameObject;
        GameObject laser2 = Instantiate(projectile, v2, Quaternion.Euler(new Vector3(0, 0, -14))) as GameObject;
        GameObject laser3 = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser1.GetComponent<Rigidbody2D>().velocity = new Vector2(0.7f, -projectile.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.7f, -projectile.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectile.GetComponent<DamageDealer>().GetProjectileSpeed());
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }
}
 