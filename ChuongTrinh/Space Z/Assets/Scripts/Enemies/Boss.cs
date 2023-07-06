using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] List<GameObject> iNeedPower;
    [SerializeField] Transform gun1;
    [SerializeField] Transform gun2;
    float shotCounter;
    float minDelay;
    float maxDelay;
    float shootSoundVolume;
    AudioClip shootSound;
    GameObject projectile;
    GameController gameController;
    float maxHealth;
    float health;
    List<GameObject> upgrades;
    GameObject player;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        gameController.BosssHPOn();
    }
    private void OnDestroy()
    {
        gameController.BosssHPOff();
    }
    IEnumerator Start()
    {
        upgrades = GetComponent<Enemy>().GetUpgrades();
        shootSound = GetComponent<Enemy>().GetShootSound();
        projectile = GetComponent<Enemy>().GetProjectile();
        shootSoundVolume = GetComponent<Enemy>().GetShootSoundVolume();
        minDelay = GetComponent<Enemy>().GetMinShootDelay();
        maxDelay = GetComponent<Enemy>().GetMaxShootDelay();
        shotCounter = Random.Range(minDelay, maxDelay);
        maxHealth = GetComponent<Enemy>().GetHealth();
        yield return new WaitForSeconds(3f);
        while (true)
        {
            int i = Random.Range(0, 4); 
            if (i == 0)
            {
                 StartCoroutine(Vergil1());
            }
            else if (i == 1)
            {
                StartCoroutine(Vergil3());
            }
            else if (i == 2)
            {
                StartCoroutine(Vergil4());
            }
            else StartCoroutine(Vergil2());
            yield return new WaitForSeconds(2f);
        }
    }
    void Update()
    {
        health = GetComponent<Enemy>().GetHealth();
        gameController.SetBossHPValue(float.Parse((health / (maxHealth * 1.0)).ToString()));

    }
    IEnumerator Vergil1()
    {
        Vector2 v1 = gun1.transform.position;
        Vector2 v2 = gun2.transform.position;
        try
        {
            player = FindObjectOfType<Player>().gameObject;
            GameObject laser1 = Instantiate(iNeedPower[0], v1, Quaternion.identity) as GameObject;
            laser1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser1.GetComponent<Rigidbody2D>().velocity = (player.transform.position - gun1.transform.position).normalized * iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed();
            GameObject laser2 = Instantiate(iNeedPower[0], v2, Quaternion.identity) as GameObject;
            laser2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser2.GetComponent<Rigidbody2D>().velocity = (player.transform.position - gun2.transform.position).normalized * iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }
        catch (System.Exception)
        {
            GameObject laser1 = Instantiate(iNeedPower[0], v1, Quaternion.identity) as GameObject;
            laser1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed());
            GameObject laser2 = Instantiate(iNeedPower[0], v2, Quaternion.identity) as GameObject;
            laser2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed());
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }
        yield return new WaitForSeconds(0.3f);

        try
        {
            player = FindObjectOfType<Player>().gameObject;
            GameObject laser3 = Instantiate(iNeedPower[0], v1, Quaternion.identity) as GameObject;
            laser3.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser3.GetComponent<Rigidbody2D>().velocity = (player.transform.position - gun1.transform.position).normalized * iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed();
            GameObject laser4 = Instantiate(iNeedPower[0], v2, Quaternion.identity) as GameObject;
            laser4.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser4.GetComponent<Rigidbody2D>().velocity = (player.transform.position - gun2.transform.position).normalized * iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }
        catch (System.Exception)
        {
            GameObject laser3 = Instantiate(iNeedPower[0], v1, Quaternion.identity) as GameObject;
            laser3.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed());
            GameObject laser4 = Instantiate(iNeedPower[0], v2, Quaternion.identity) as GameObject;
            laser4.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser4.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed());
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }

        yield return new WaitForSeconds(0.3f);
        try
        {
            player = FindObjectOfType<Player>().gameObject;
            GameObject laser5 = Instantiate(iNeedPower[0], v1, Quaternion.identity) as GameObject;
            laser5.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser5.GetComponent<Rigidbody2D>().velocity = (player.transform.position - gun1.transform.position).normalized * iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed();
            GameObject laser6 = Instantiate(iNeedPower[0], v2, Quaternion.identity) as GameObject;
            laser6.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser6.GetComponent<Rigidbody2D>().velocity = (player.transform.position - gun2.transform.position).normalized * iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }
        catch (System.Exception)
        {
            GameObject laser5 = Instantiate(iNeedPower[0], v1, Quaternion.identity) as GameObject;
            laser5.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser5.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed());
            GameObject laser6 = Instantiate(iNeedPower[0], v2, Quaternion.identity) as GameObject;
            laser6.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser6.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed());
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);

        }

        yield return new WaitForSeconds(0.3f);
        try
        {
            player = FindObjectOfType<Player>().gameObject;
            GameObject laser7 = Instantiate(iNeedPower[0], v1, Quaternion.identity) as GameObject;
            laser7.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser7.GetComponent<Rigidbody2D>().velocity = (player.transform.position - gun1.transform.position).normalized * iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed();
            GameObject laser8 = Instantiate(iNeedPower[0], v2, Quaternion.identity) as GameObject;
            laser8.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser8.GetComponent<Rigidbody2D>().velocity = (player.transform.position - gun2.transform.position).normalized * iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }
        catch (System.Exception)
        {
            GameObject laser7 = Instantiate(iNeedPower[0], v1, Quaternion.identity) as GameObject;
            laser7.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser7.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed());
            GameObject laser8 = Instantiate(iNeedPower[0], v2, Quaternion.identity) as GameObject;
            laser8.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser8.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed());
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);

        }

        yield return new WaitForSeconds(0.3f);
        try
        {
            player = FindObjectOfType<Player>().gameObject;
            GameObject laser9 = Instantiate(iNeedPower[0], v1, Quaternion.identity) as GameObject;
            laser9.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser9.GetComponent<Rigidbody2D>().velocity = (player.transform.position - gun1.transform.position).normalized * iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed();
            GameObject laser10 = Instantiate(iNeedPower[0], v2, Quaternion.identity) as GameObject;
            laser10.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser10.GetComponent<Rigidbody2D>().velocity = (player.transform.position - gun2.transform.position).normalized * iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }
        catch (System.Exception)
        {
            GameObject laser9 = Instantiate(iNeedPower[0], v1, Quaternion.identity) as GameObject;
            laser9.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser9.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed());
            GameObject laser10 = Instantiate(iNeedPower[0], v2, Quaternion.identity) as GameObject;
            laser10.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            laser10.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -iNeedPower[0].GetComponent<DamageDealer>().GetProjectileSpeed());
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }
    }
    IEnumerator Vergil2()
    {
        GameObject shoot1 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 180))) as GameObject;
        GameObject shoot2 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 45))) as GameObject;
        GameObject shoot3 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, -45))) as GameObject;
        GameObject shoot4 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 90))) as GameObject;
        GameObject shoot5 = Instantiate(iNeedPower[1], transform.position, Quaternion.identity) as GameObject;
        GameObject shoot6 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, -90))) as GameObject;
        GameObject shoot7 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 135))) as GameObject;
        GameObject shoot8 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, -135))) as GameObject;
        shoot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, shoot1.GetComponent<DamageDealer>().GetProjectileSpeed());
        shoot2.GetComponent<Rigidbody2D>().velocity = new Vector2(shoot2.GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f, -shoot2.GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f);
        shoot3.GetComponent<Rigidbody2D>().velocity = new Vector2(-shoot3.GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f, -shoot3.GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f);
        shoot4.GetComponent<Rigidbody2D>().velocity = new Vector2(shoot4.GetComponent<DamageDealer>().GetProjectileSpeed(), 0f);
        shoot5.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -shoot5.GetComponent<DamageDealer>().GetProjectileSpeed());
        shoot6.GetComponent<Rigidbody2D>().velocity = new Vector2(-shoot6.GetComponent<DamageDealer>().GetProjectileSpeed(), 0f);
        shoot7.GetComponent<Rigidbody2D>().velocity = new Vector2(shoot7.GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f, shoot7.GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f);
        shoot8.GetComponent<Rigidbody2D>().velocity = new Vector2(-shoot8.GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f, shoot8.GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f);
        yield return new WaitForSeconds(0.5f);
        GameObject shoot9 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 210))) as GameObject;
        GameObject shoot10 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 75))) as GameObject;
        GameObject shoot11 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 255))) as GameObject;
        GameObject shoot12 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 120))) as GameObject;
        GameObject shoot13 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 30))) as GameObject;
        GameObject shoot14 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 300))) as GameObject;
        GameObject shoot15 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 165))) as GameObject;
        GameObject shoot16 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 345))) as GameObject;
        shoot9.GetComponent<Rigidbody2D>().velocity = new Vector2(-shoot9.GetComponent<DamageDealer>().GetProjectileSpeed() / 2, shoot9.GetComponent<DamageDealer>().GetProjectileSpeed() * Mathf.Sqrt(3) / 2);
        shoot10.GetComponent<Rigidbody2D>().velocity = new Vector2(shoot10.GetComponent<DamageDealer>().GetProjectileSpeed() * Mathf.Sqrt(2 + Mathf.Sqrt(3)) / 2, -shoot10.GetComponent<DamageDealer>().GetProjectileSpeed() / (2 * Mathf.Sqrt(2 + Mathf.Sqrt(3))));
        shoot11.GetComponent<Rigidbody2D>().velocity = new Vector2(-shoot11.GetComponent<DamageDealer>().GetProjectileSpeed() * Mathf.Sqrt(2 + Mathf.Sqrt(3)) / 2, shoot11.GetComponent<DamageDealer>().GetProjectileSpeed() / (2 * Mathf.Sqrt(2 + Mathf.Sqrt(3))));
        shoot12.GetComponent<Rigidbody2D>().velocity = new Vector2(shoot12.GetComponent<DamageDealer>().GetProjectileSpeed() * Mathf.Sqrt(3) / 2, shoot12.GetComponent<DamageDealer>().GetProjectileSpeed() / 2);
        shoot13.GetComponent<Rigidbody2D>().velocity = new Vector2(shoot13.GetComponent<DamageDealer>().GetProjectileSpeed() / 2, -shoot13.GetComponent<DamageDealer>().GetProjectileSpeed() * Mathf.Sqrt(3) / 2);
        shoot14.GetComponent<Rigidbody2D>().velocity = new Vector2(-shoot12.GetComponent<DamageDealer>().GetProjectileSpeed() * Mathf.Sqrt(3) / 2, -shoot12.GetComponent<DamageDealer>().GetProjectileSpeed() / 2);
        shoot15.GetComponent<Rigidbody2D>().velocity = new Vector2(shoot10.GetComponent<DamageDealer>().GetProjectileSpeed() / (2 * Mathf.Sqrt(2 + Mathf.Sqrt(3))), shoot10.GetComponent<DamageDealer>().GetProjectileSpeed() * Mathf.Sqrt(2 + Mathf.Sqrt(3)) / 2);
        shoot16.GetComponent<Rigidbody2D>().velocity = new Vector2(-shoot10.GetComponent<DamageDealer>().GetProjectileSpeed() / (2 * Mathf.Sqrt(2 + Mathf.Sqrt(3))), -shoot10.GetComponent<DamageDealer>().GetProjectileSpeed() * Mathf.Sqrt(2 + Mathf.Sqrt(3)) / 2);
        yield return new WaitForSeconds(0.5f);
        GameObject shoot17 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 240))) as GameObject;
        GameObject shoot18 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 105))) as GameObject;
        GameObject shoot19 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 285))) as GameObject;
        GameObject shoot20 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 150))) as GameObject;
        GameObject shoot21 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 60))) as GameObject;
        GameObject shoot22 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 330))) as GameObject;
        GameObject shoot23 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 195))) as GameObject;
        GameObject shoot24 = Instantiate(iNeedPower[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 15))) as GameObject;
        shoot17.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Sqrt(3) * shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / 2, shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / 2);
        shoot18.GetComponent<Rigidbody2D>().velocity = new Vector2(shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / (2 * Mathf.Sqrt(2 - Mathf.Sqrt(3))), Mathf.Sqrt(2 - Mathf.Sqrt(3)) * shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / 2);
        shoot19.GetComponent<Rigidbody2D>().velocity = new Vector2(-shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / (2 * Mathf.Sqrt(2 - Mathf.Sqrt(3))), -Mathf.Sqrt(2 - Mathf.Sqrt(3)) * shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / 2);
        shoot20.GetComponent<Rigidbody2D>().velocity = new Vector2(shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / 2, Mathf.Sqrt(3) * shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / 2);
        shoot21.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sqrt(3) * shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / 2, -shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / 2);
        shoot22.GetComponent<Rigidbody2D>().velocity = new Vector2(-shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / 2, -Mathf.Sqrt(3) * shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / 2);
        shoot23.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Sqrt(2 - Mathf.Sqrt(3)) * shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / 2, shoot21.GetComponent<DamageDealer>().GetProjectileSpeed() / (2 * Mathf.Sqrt(2 - Mathf.Sqrt(3))));
        shoot24.GetComponent<Rigidbody2D>().velocity = new Vector2(-shoot24.GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f, shoot24.GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f);
    }
    IEnumerator Vergil3()
    {
        GameObject laser1 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        GameObject laser2 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        GameObject laser3 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        laser1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser3.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser1.GetComponent<Rigidbody2D>().velocity = new Vector2(laser1.GetComponent<DamageDealer>().GetProjectileSpeed(), laser1.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laser2.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser3.GetComponent<Rigidbody2D>().velocity = new Vector2(-laser3.GetComponent<DamageDealer>().GetProjectileSpeed(), laser3.GetComponent<DamageDealer>().GetProjectileSpeed());
        yield return new WaitForSeconds(0.5f);
        GameObject laser4 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        GameObject laser5 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        GameObject laser6 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        laser4.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser5.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser6.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser4.GetComponent<Rigidbody2D>().velocity = new Vector2(laser4.GetComponent<DamageDealer>().GetProjectileSpeed(), laser4.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser5.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laser5.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser6.GetComponent<Rigidbody2D>().velocity = new Vector2(-laser6.GetComponent<DamageDealer>().GetProjectileSpeed(), laser6.GetComponent<DamageDealer>().GetProjectileSpeed());
        yield return new WaitForSeconds(0.5f);
        GameObject laser7 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        GameObject laser8 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        GameObject laser9 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        laser7.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser8.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser9.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser7.GetComponent<Rigidbody2D>().velocity = new Vector2(laser7.GetComponent<DamageDealer>().GetProjectileSpeed(), laser7.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser8.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laser8.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser9.GetComponent<Rigidbody2D>().velocity = new Vector2(-laser9.GetComponent<DamageDealer>().GetProjectileSpeed(), laser9.GetComponent<DamageDealer>().GetProjectileSpeed());
        yield return new WaitForSeconds(0.5f);
        GameObject laser10 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        GameObject laser11 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        GameObject laser12 = Instantiate(iNeedPower[2], transform.position, Quaternion.identity) as GameObject;
        laser10.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser11.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser12.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser10.GetComponent<Rigidbody2D>().velocity = new Vector2(laser10.GetComponent<DamageDealer>().GetProjectileSpeed(), laser10.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser11.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laser11.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser12.GetComponent<Rigidbody2D>().velocity = new Vector2(-laser12.GetComponent<DamageDealer>().GetProjectileSpeed(), laser12.GetComponent<DamageDealer>().GetProjectileSpeed());
    }
    IEnumerator Vergil4()
    {
        Vector2 v1 = new Vector2(transform.position.x - 0.5f, transform.position.y);
        Vector2 v2 = new Vector2(transform.position.x + 0.5f, transform.position.y);
        GameObject laser1 = Instantiate(iNeedPower[3], transform.position, Quaternion.identity) as GameObject;
        GameObject laser2 = Instantiate(iNeedPower[3], v1, Quaternion.Euler(new Vector3(0, 0, -17))) as GameObject;
        GameObject laser3 = Instantiate(iNeedPower[3], v2, Quaternion.Euler(new Vector3(0, 0, 17))) as GameObject;
        laser1.transform.localScale = new Vector3(3, 3, 3);
        laser2.transform.localScale = new Vector3(3, 3, 3);
        laser3.transform.localScale = new Vector3(3, 3, 3);
        laser3.GetComponent<Rigidbody2D>().velocity = new Vector2(laser3.GetComponent<DamageDealer>().GetProjectileSpeed()/3, -laser3.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(-laser2.GetComponent<DamageDealer>().GetProjectileSpeed()/3, -laser2.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laser1.GetComponent<DamageDealer>().GetProjectileSpeed());
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        yield return new WaitForSeconds(0.3f);
        GameObject laser4 = Instantiate(iNeedPower[4], transform.position, Quaternion.identity) as GameObject;
        GameObject laser5 = Instantiate(iNeedPower[4], transform.position, Quaternion.identity) as GameObject;
        laser4.transform.localScale = new Vector3(4, 4, 4);
        laser5.transform.localScale = new Vector3(4, 4, 4);
        laser4.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser5.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser4.GetComponent<Rigidbody2D>().velocity = new Vector2(-laser4.GetComponent<DamageDealer>().GetProjectileSpeed()/2, laser4.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser5.GetComponent<Rigidbody2D>().velocity = new Vector2(laser5.GetComponent<DamageDealer>().GetProjectileSpeed()/2, laser5.GetComponent<DamageDealer>().GetProjectileSpeed());
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        yield return new WaitForSeconds(0.3f);
        GameObject laser6 = Instantiate(iNeedPower[3], transform.position, Quaternion.identity) as GameObject;
        GameObject laser7 = Instantiate(iNeedPower[3], v1, Quaternion.Euler(new Vector3(0, 0, -17))) as GameObject;
        GameObject laser8 = Instantiate(iNeedPower[3], v2, Quaternion.Euler(new Vector3(0, 0, 17))) as GameObject;
        laser6.transform.localScale = new Vector3(3, 3, 3);
        laser7.transform.localScale = new Vector3(3, 3, 3); 
        laser8.transform.localScale = new Vector3(3, 3, 3);
        laser8.GetComponent<Rigidbody2D>().velocity = new Vector2(laser8.GetComponent<DamageDealer>().GetProjectileSpeed()/3, -laser8.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser7.GetComponent<Rigidbody2D>().velocity = new Vector2(-laser7.GetComponent<DamageDealer>().GetProjectileSpeed()/3, -laser7.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser6.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laser6.GetComponent<DamageDealer>().GetProjectileSpeed());
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        yield return new WaitForSeconds(0.3f);
        GameObject laser9 = Instantiate(iNeedPower[4], transform.position, Quaternion.identity) as GameObject;
        GameObject laser10 = Instantiate(iNeedPower[4], transform.position, Quaternion.identity) as GameObject;
        laser9.transform.localScale = new Vector3(4, 4, 4);
        laser10.transform.localScale = new Vector3(4, 4, 4);
        laser9.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser10.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser9.GetComponent<Rigidbody2D>().velocity = new Vector2(-laser9.GetComponent<DamageDealer>().GetProjectileSpeed()/2, laser9.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser10.GetComponent<Rigidbody2D>().velocity = new Vector2(laser10.GetComponent<DamageDealer>().GetProjectileSpeed()/2, laser10.GetComponent<DamageDealer>().GetProjectileSpeed());
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        yield return new WaitForSeconds(0.3f);
        
        GameObject laser11 = Instantiate(iNeedPower[3], transform.position, Quaternion.identity) as GameObject;
        GameObject laser12 = Instantiate(iNeedPower[3], v1, Quaternion.Euler(new Vector3(0, 0, -17))) as GameObject;
        GameObject laser13 = Instantiate(iNeedPower[3], v2, Quaternion.Euler(new Vector3(0, 0, 17))) as GameObject;
        laser11.transform.localScale = new Vector3(3, 3, 3);
        laser12.transform.localScale = new Vector3(3, 3, 3);
        laser13.transform.localScale = new Vector3(3, 3, 3);
        laser13.GetComponent<Rigidbody2D>().velocity = new Vector2(laser13.GetComponent<DamageDealer>().GetProjectileSpeed()/3, -laser13.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser12.GetComponent<Rigidbody2D>().velocity = new Vector2(-laser12.GetComponent<DamageDealer>().GetProjectileSpeed()/3, -laser12.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser11.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laser11.GetComponent<DamageDealer>().GetProjectileSpeed());
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        yield return new WaitForSeconds(0.3f);
        GameObject laser14 = Instantiate(iNeedPower[4], transform.position, Quaternion.identity) as GameObject;
        GameObject laser15 = Instantiate(iNeedPower[4], transform.position, Quaternion.identity) as GameObject;
        laser14.transform.localScale = new Vector3(4, 4, 4);
        laser15.transform.localScale = new Vector3(4, 4, 4);
        laser14.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser15.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        laser14.GetComponent<Rigidbody2D>().velocity = new Vector2(-laser14.GetComponent<DamageDealer>().GetProjectileSpeed()/2, laser14.GetComponent<DamageDealer>().GetProjectileSpeed());
        laser15.GetComponent<Rigidbody2D>().velocity = new Vector2(laser15.GetComponent<DamageDealer>().GetProjectileSpeed()/2, laser15.GetComponent<DamageDealer>().GetProjectileSpeed());
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        yield return new WaitForSeconds(0.3f);
    }
    
} 