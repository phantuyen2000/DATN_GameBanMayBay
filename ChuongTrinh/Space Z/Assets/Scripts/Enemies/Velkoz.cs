using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velkoz : MonoBehaviour
{
    public void VelkozActive()
    {
        GameObject laser1 = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
        GameObject laser2 = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
        laser1.GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<DamageDealer>().GetProjectileSpeed()*0.6f, -GetComponent<DamageDealer>().GetProjectileSpeed()*0.6f);
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f, -GetComponent<DamageDealer>().GetProjectileSpeed() * 0.6f);
        Destroy(gameObject);
    }
}
