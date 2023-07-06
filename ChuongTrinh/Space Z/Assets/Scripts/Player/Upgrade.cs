using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] int upgradeId;
    [SerializeField] string upgradeType;
    public int GetUpgradeID()
    {
        return upgradeId;
    }
    public string GetUpgradeType()
    {
        return upgradeType;
    }
    public void Recieved()
    {
        Destroy(gameObject);
    }
}
