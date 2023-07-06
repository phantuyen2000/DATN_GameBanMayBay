using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stas")]
    [SerializeField] float health = 1;
    [SerializeField] int scoreValue = 100;
    [Header("Shooting")]
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [Header("Sound Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
    [Header("Upgrade")]
    [SerializeField] List<GameObject> upgrades;
    EnemySpawner spawner;
    private void Awake()
    {
        spawner = FindObjectOfType<EnemySpawner>();
        spawner.EnemyAppear();
    }
    private void OnDestroy()
    {
        spawner.EnemyKilled();
    }
    public List<GameObject> GetUpgrades()
    {
        return upgrades;
    }
    public float GetMaxShootDelay()
    {
        return maxTimeBetweenShots;
    }
    public float GetMinShootDelay()
    {
        return minTimeBetweenShots;
    }
    public GameObject GetProjectile()
    {
        return projectile;
    }
    public AudioClip GetShootSound()
    {
        return shootSound;
    }
    public float GetShootSoundVolume()
    {
        return shootSoundVolume;
    }
    public float GetHealth()
    {
        return health;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        
        if (damageDealer)
        {
            health -= damageDealer.GetDamage();
            if (health <= 0)
            {
                Die();
            }
            if (other.gameObject.tag == "Weeboo" && FindObjectOfType<Player>().GetProjectileLevel() == 5)
            {

            }
            else
            {
                if (damageDealer.tag != "Player")
                {
                    damageDealer.Hit();
                }
            }
        }
    }

    private void Die()
    {
        int decision = Random.Range(0, 8);
        if (decision == 4)
        {
            int ran = Random.Range(0, 5);
            GameObject upgrade = Instantiate(upgrades[ran], transform.position, Quaternion.identity);
            upgrade.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
        }
        if (tag == "Boss")
        {
            int ran = Random.Range(0, 5);
            GameObject upgrade = Instantiate(upgrades[ran], new Vector2(transform.position.x+0.5f, transform.position.y), Quaternion.identity);
            upgrade.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
            GameObject upgrade1 = Instantiate(upgrades[ran], new Vector2(transform.position.x - 0.5f, transform.position.y), Quaternion.identity);
            upgrade1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
        }
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        if (explosion != null)
        {
            Destroy(explosion, durationOfExplosion);
        }
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
    public void StrongerOverTime(float bonusHp, float atkSpeed)
    {
        health += bonusHp;
        if (maxTimeBetweenShots - atkSpeed >= minTimeBetweenShots)
        {
            maxTimeBetweenShots = maxTimeBetweenShots - atkSpeed;
        }
        else
        {
            maxTimeBetweenShots = minTimeBetweenShots;
        }
    }
}
