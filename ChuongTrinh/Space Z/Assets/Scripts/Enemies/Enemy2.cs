using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
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
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.transform.localScale = new Vector3(2f, 2f, 2f);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectile.GetComponent<DamageDealer>().GetProjectileSpeed());
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }
}
