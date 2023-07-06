using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float delay = 0.2f;

    public int GetDamage()
    {
        return damage;
    }
    public void SetDamage(int dmg)
    {
        this.damage = dmg;
    }
    public float GetProjectileSpeed()
    {
        return projectileSpeed;
    }

    public float GetDelay()
    {
        return delay;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
