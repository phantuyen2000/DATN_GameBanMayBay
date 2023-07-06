using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    Vector3 worldPosition;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.2f;
    [SerializeField] int health = 5;

    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
    [Header("Projectile")]
    [SerializeField] List<GameObject> projectiles;
    [SerializeField] int projectileLevel = 1;
    [SerializeField] int projectileId = 0;
    Coroutine firingCoroutine;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
 
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Fire(projectileId);
    }

    #region Nang cap dan
    public void UpgradeProjectile()
    {
        if (projectileLevel < 5)
        {
            projectileLevel++;
        }
    }

    #endregion
    
    #region Tra ve nang cap
    public int GetProjectileLevel()
    {
        return projectileLevel;
    }
    #endregion

    #region  Cach ban dan cua nguoi choi vs nang cap
    private void Fire(int id)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (id == 0)
            {
                firingCoroutine = StartCoroutine(RedAmmo());
            }
            if(id == 1)
            {
                firingCoroutine = StartCoroutine(BlueAmmo());
            }
            if (id == 2)
            {
                firingCoroutine = StartCoroutine(WeebooAmmo());
            }
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator RedAmmo()
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(shootSound);
            if (projectileLevel == 1)
            {
                GameObject shoot = Instantiate(projectiles[0], transform.position, Quaternion.identity) as GameObject;
                shoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot.GetComponent<DamageDealer>().GetDelay());
            }
            if (projectileLevel == 2)
            {
                Vector2 place1 = new Vector2(transform.position.x - 0.1f, transform.position.y);
                Vector2 place2 = new Vector2(transform.position.x + 0.1f, transform.position.y);
                GameObject shoot1 = Instantiate(projectiles[0], place1, Quaternion.identity) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[0], place2, Quaternion.identity) as GameObject;
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay());
            }
            if (projectileLevel == 3)
            {
                Vector2 place1 = new Vector2(transform.position.x - 0.1f, transform.position.y);
                Vector2 place2 = new Vector2(transform.position.x + 0.1f, transform.position.y);
                Vector2 place3 = new Vector2(transform.position.x, transform.position.y + 0.2f);
                GameObject shoot1 = Instantiate(projectiles[0], place1, Quaternion.identity) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[0], place2, Quaternion.identity) as GameObject;
                GameObject shoot3 = Instantiate(projectiles[0], place3, Quaternion.identity) as GameObject;
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot3.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay() / 1.5f);
            }
            if (projectileLevel == 4)
            {
                Vector2 place1 = new Vector2(transform.position.x - 0.2f, transform.position.y);
                Vector2 place2 = new Vector2(transform.position.x + 0.2f, transform.position.y);
                Vector2 place3 = new Vector2(transform.position.x - 0.1f, transform.position.y + 0.2f);
                Vector2 place4 = new Vector2(transform.position.x + 0.1f, transform.position.y + 0.2f);
                GameObject shoot1 = Instantiate(projectiles[0], place1, Quaternion.identity) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[0], place2, Quaternion.identity) as GameObject;
                GameObject shoot3 = Instantiate(projectiles[0], place3, Quaternion.identity) as GameObject;
                GameObject shoot4 = Instantiate(projectiles[0], place4, Quaternion.identity) as GameObject;
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot3.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot4.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot4.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay() / 1.5f);
            }
            if (projectileLevel == 5)
            {
                Vector2 place1 = new Vector2(transform.position.x - 0.2f, transform.position.y);
                Vector2 place2 = new Vector2(transform.position.x + 0.2f, transform.position.y);
                Vector2 place3 = new Vector2(transform.position.x - 0.1f, transform.position.y + 0.2f);
                Vector2 place4 = new Vector2(transform.position.x + 0.1f, transform.position.y + 0.2f);
                GameObject shoot1 = Instantiate(projectiles[0], place1, Quaternion.identity) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[0], place2, Quaternion.identity) as GameObject;
                GameObject shoot3 = Instantiate(projectiles[0], place3, Quaternion.identity) as GameObject;
                GameObject shoot4 = Instantiate(projectiles[0], place4, Quaternion.identity) as GameObject;
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot3.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot4.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot4.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay() / 3f);
            } 
        }
    }
    IEnumerator BlueAmmo()
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(shootSound);
            if (projectileLevel==1)
            {
                Vector2 v1 = new Vector2(transform.position.x + 0.1f, transform.position.y);
                Vector2 v2 = new Vector2(transform.position.x - 0.1f, transform.position.y);
                GameObject shoot1 = Instantiate(projectiles[1], v1, Quaternion.identity) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[1], v2, Quaternion.identity) as GameObject;
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay());
            }
            if (projectileLevel == 2)
            {
                Vector2 v1 = new Vector2(transform.position.x + 0.15f, transform.position.y-0.2f);
                Vector2 v2 = new Vector2(transform.position.x - 0.15f, transform.position.y-0.2f);
                Vector2 v3 = new Vector2(transform.position.x, transform.position.y + 0.1f);
                GameObject shoot1 = Instantiate(projectiles[1], v1, Quaternion.Euler(new Vector3(0, 0, -7))) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[1], v2, Quaternion.Euler(new Vector3(0, 0, 7))) as GameObject;
                GameObject shoot3 = Instantiate(projectiles[1], v3, Quaternion.identity) as GameObject;
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0.7f, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.7f, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot3.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay());
            }
            if (projectileLevel == 3)
            {
                Vector2 v1 = new Vector2(transform.position.x + 0.15f, transform.position.y - 0.2f);
                Vector2 v2 = new Vector2(transform.position.x - 0.15f, transform.position.y - 0.2f);
                Vector2 v3 = new Vector2(transform.position.x + 0.1f, transform.position.y + 0.05f);
                Vector2 v4 = new Vector2(transform.position.x - 0.1f, transform.position.y + 0.05f);
                GameObject shoot1 = Instantiate(projectiles[1], v1, Quaternion.Euler(new Vector3(0, 0, -7))) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[1], v2, Quaternion.Euler(new Vector3(0, 0, 7))) as GameObject;
                GameObject shoot3 = Instantiate(projectiles[1], v3, Quaternion.identity) as GameObject;
                GameObject shoot4 = Instantiate(projectiles[1], v4, Quaternion.identity) as GameObject;
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot3.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot4.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot4.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay());
            }
            if (projectileLevel == 4)
            {
                Vector2 v1 = new Vector2(transform.position.x + 0.15f, transform.position.y - 0.2f);
                Vector2 v2 = new Vector2(transform.position.x - 0.15f, transform.position.y - 0.2f);
                Vector2 v3 = new Vector2(transform.position.x + 0.15f, transform.position.y + 0.05f);
                Vector2 v4 = new Vector2(transform.position.x - 0.15f, transform.position.y + 0.05f);
                Vector2 v5 = new Vector2(transform.position.x, transform.position.y + 0.5f);
                GameObject shoot1 = Instantiate(projectiles[1], v1, Quaternion.Euler(new Vector3(0, 0, -8))) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[1], v2, Quaternion.Euler(new Vector3(0, 0, 8))) as GameObject;
                GameObject shoot3 = Instantiate(projectiles[1], v3, Quaternion.Euler(new Vector3(0, 0, -4))) as GameObject;
                GameObject shoot4 = Instantiate(projectiles[1], v4, Quaternion.Euler(new Vector3(0, 0, 4))) as GameObject;
                GameObject shoot5 = Instantiate(projectiles[1], v5, Quaternion.identity) as GameObject;
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot3.GetComponent<Rigidbody2D>().velocity = new Vector2(0.4f, shoot3.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot4.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.4f, shoot4.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot5.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot5.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay());
            }
            if (projectileLevel == 5)
            {
                Vector2 v1 = new Vector2(transform.position.x + 0.15f, transform.position.y - 0.2f);
                Vector2 v2 = new Vector2(transform.position.x - 0.15f, transform.position.y - 0.2f);
                
                Vector2 v3 = new Vector2(transform.position.x + 0.15f, transform.position.y + 0.05f);
                Vector2 v4 = new Vector2(transform.position.x - 0.15f, transform.position.y + 0.05f);
                Vector2 v5 = new Vector2(transform.position.x, transform.position.y + 0.5f);

                Vector2 v6 = new Vector2(transform.position.x + 0.17f, transform.position.y - 0.3f);
                Vector2 v7 = new Vector2(transform.position.x - 0.17f, transform.position.y - 0.3f);

                GameObject shoot1 = Instantiate(projectiles[1], v1, Quaternion.Euler(new Vector3(0, 0, -8))) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[1], v2, Quaternion.Euler(new Vector3(0, 0, 8))) as GameObject;
                GameObject shoot3 = Instantiate(projectiles[1], v3, Quaternion.Euler(new Vector3(0, 0, -4))) as GameObject;
                GameObject shoot4 = Instantiate(projectiles[1], v4, Quaternion.Euler(new Vector3(0, 0, 4))) as GameObject;
                GameObject shoot5 = Instantiate(projectiles[1], v5, Quaternion.identity) as GameObject;
                GameObject shoot6 = Instantiate(projectiles[1], v6, Quaternion.Euler(new Vector3(0, 0, -12))) as GameObject;
                GameObject shoot7 = Instantiate(projectiles[1], v7, Quaternion.Euler(new Vector3(0, 0, 12))) as GameObject;

                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0.8f, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.8f, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot3.GetComponent<Rigidbody2D>().velocity = new Vector2(0.4f, shoot3.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot4.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.4f, shoot4.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot5.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot5.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot6.GetComponent<Rigidbody2D>().velocity = new Vector2(1.2f, shoot6.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot7.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.2f, shoot7.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay());
            }
        }
    }

    IEnumerator WeebooAmmo()
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(shootSound);
            if(projectileLevel==1)
            {
                GameObject shoot = Instantiate(projectiles[2], transform.position, Quaternion.identity) as GameObject;
                shoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot.GetComponent<DamageDealer>().GetDelay());
            }
            if (projectileLevel == 2)
            {
                Vector2 v1 = new Vector2(transform.position.x + 0.1f, transform.position.y);
                Vector2 v2 = new Vector2(transform.position.x - 0.1f, transform.position.y);
                GameObject shoot1 = Instantiate(projectiles[2], v1, Quaternion.identity) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[2], v2, Quaternion.identity) as GameObject;
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay());
            }
            if (projectileLevel == 3)
            {
                Vector2 v1 = new Vector2(transform.position.x + 0.2f, transform.position.y-0.2f);
                Vector2 v2 = new Vector2(transform.position.x - 0.2f, transform.position.y-0.2f);
                GameObject shoot1 = Instantiate(projectiles[2], v1, Quaternion.identity) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[2], v2, Quaternion.identity) as GameObject;
                GameObject shoot3 = Instantiate(projectiles[2], transform.position, Quaternion.identity) as GameObject;
                shoot3.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                shoot3.GetComponent<DamageDealer>().SetDamage(int.Parse((shoot3.GetComponent<DamageDealer>().GetDamage() * 1.3f).ToString()));
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot3.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay());
            }
            if (projectileLevel == 4)
            {
                Vector2 v1 = new Vector2(transform.position.x + 0.2f, transform.position.y - 0.2f);
                Vector2 v2 = new Vector2(transform.position.x - 0.2f, transform.position.y - 0.2f);
                GameObject shoot1 = Instantiate(projectiles[2], v1, Quaternion.identity) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[2], v2, Quaternion.identity) as GameObject;
                shoot1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                shoot1.GetComponent<DamageDealer>().SetDamage(int.Parse((shoot1.GetComponent<DamageDealer>().GetDamage() * 1.9f).ToString()));
                shoot2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                shoot2.GetComponent<DamageDealer>().SetDamage(int.Parse((shoot2.GetComponent<DamageDealer>().GetDamage() * 1.9f).ToString()));
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay());
            }
            if (projectileLevel == 5)
            {
                Vector2 v1 = new Vector2(transform.position.x + 0.3f, transform.position.y - 0.2f);
                Vector2 v2 = new Vector2(transform.position.x - 0.3f, transform.position.y - 0.2f);
                GameObject shoot1 = Instantiate(projectiles[2], v1, Quaternion.identity) as GameObject;
                GameObject shoot2 = Instantiate(projectiles[2], v2, Quaternion.identity) as GameObject;
                GameObject shoot3 = Instantiate(projectiles[2], transform.position, Quaternion.identity) as GameObject;
                shoot3.transform.localScale = new Vector3(2f, 2f, 2f);
                shoot3.GetComponent<DamageDealer>().SetDamage(int.Parse((shoot3.GetComponent<DamageDealer>().GetDamage() * 3f).ToString()));
                shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot2.GetComponent<DamageDealer>().GetProjectileSpeed());
                shoot3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shoot3.GetComponent<DamageDealer>().GetProjectileSpeed());
                yield return new WaitForSeconds(shoot1.GetComponent<DamageDealer>().GetDelay());
            }
        }
    }
    #endregion

    #region Tra Damge va Nhan Damge
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        Upgrade upgrade = other.gameObject.GetComponent<Upgrade>();
        if (damageDealer)
        {
            health -= damageDealer.GetDamage();
            if (projectileLevel > 1)
            {
                projectileLevel -= 1;
            }
            else
            {
                projectileLevel = 1;
            }
            if (health <= 0)
            {
                Die();
            }
            if (damageDealer.tag == "EnemyProjectile")
            {
                damageDealer.Hit();
            }
        }
        else if (upgrade)
        {
            if(upgrade.GetUpgradeType()== "ammo")
            {
                if(projectileId== upgrade.GetUpgradeID())
                {
                    UpgradeProjectile();
                }
                else
                {
                    projectileId = upgrade.GetUpgradeID();
                }
            }
            else if (upgrade.GetUpgradeType() == "health")
            {
                health += 1;
            }
            else
            {
                UpgradeProjectile();
            }
            upgrade.Recieved(); 
        }
        else
        {
            return;
        }
    }
    #endregion

    #region Tra ve mau
public int GetHealth()
    {
        return health;
    }
    #endregion

    #region Pha huy vat the
    private void Die()
    {
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
    #endregion

    #region Theo doi vi tri
    private void FixedUpdate()
    {
        this.worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.worldPosition.z = 0;

        Vector3 newPos = Vector3.Lerp(transform.position, worldPosition, this.moveSpeed);
        var x = Mathf.Clamp(newPos.x, xMin, xMax);
        var y = Mathf.Clamp(newPos.y, yMin, yMax);
        transform.position = new Vector3(x, y, worldPosition.z);
    }
    #endregion

    #region Gioi han di chuyen
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    #endregion
}
