using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /// Enemy should be a scriptable object
    [SerializeField]
    private GameObject spawnedEnemyPrefab;

    /// The intended destination of enemies spawned from here
    [SerializeField]
    private Transform endPoint;

    private Pooler pooler;

    private void Awake()
    {
        pooler = new Pooler(spawnedEnemyPrefab);
        SpawnAtIntervals();
    }


    private void SpawnEnemy()
    {
        GameObject enemyObj = pooler.GetPooledObject();
        enemyObj.transform.position = transform.position;
        EnemyBaseClass enemy = enemyObj.GetComponent<EnemyBaseClass>();
        enemy.SetDestination(endPoint.position);
    }

    private void SpawnAtIntervals()
    {
        InvokeRepeating("SpawnEnemy", 1, 2);
    }
}
