using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : MonoBehaviour
{
    float shotCounter;
    float minDelay;
    float maxDelay;
    float shootSoundVolume;
    AudioClip shootSound;
    GameObject projectile;
    GameObject player;
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
        try
        {
            player = FindObjectOfType<Player>().gameObject;
            if (player != null)
            {
                CountDownAndShoot();
            }
        }
        catch (System.Exception)
        {
            CountDownAndShoot1();
        }
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
    private void CountDownAndShoot1()
    {

        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire1();
            shotCounter = Random.Range(minDelay, maxDelay);
        }
    }
    private void Fire() 
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        laser.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * projectile.GetComponent<DamageDealer>().GetProjectileSpeed();
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }
    #region bắn đạn xuống dưới khi không đối tượng Player bị phá hủy
    private void Fire1()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        laser.GetComponent<Rigidbody2D>().velocity = 
            new Vector2(0, -projectile.GetComponent<DamageDealer>().GetProjectileSpeed());
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }
    #endregion
}
