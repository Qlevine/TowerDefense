using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower",menuName = "TowerCreation")]
public class TowerSO : ScriptableObject
{
    public float damage;
    public float attackSpeed;
    [Range(2,100)]
    public float bulletSpeed;
    public float range;
    public int size;
    public GameObject bulletPrefab;
}
