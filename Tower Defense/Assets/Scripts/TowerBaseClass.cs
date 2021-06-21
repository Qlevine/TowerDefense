using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseClass : MonoBehaviour
{
    [SerializeField]
    protected TowerSO towerSO;


    private Pooler bulletPooler;


    private Vector3 planarPosition;

    private Vector3 position;

    protected float initialAngle = 90;
    protected virtual void Awake()
    {
        bulletPooler = new Pooler(towerSO.bulletPrefab);
        planarPosition = new Vector3(transform.position.x, 0, transform.position.z);
        position = transform.position;
    }

    private void Start()
    {
        StartCoroutine(TestShoot(Vector3.zero));
    }


    private IEnumerator TestShoot(Vector3 location)
    {
        yield return new WaitForSeconds((float)(1/towerSO.attackSpeed));
        ShootAtLocation(Vector3.zero);
        StartCoroutine(TestShoot(location));

    }

    protected virtual void ShootAtLocation(Vector3 location)
    {
        GameObject bulletObj = bulletPooler.GetPooledObject();
        bulletObj.transform.position = transform.position;
        BulletBaseClass bullet = bulletObj.GetComponent<BulletBaseClass>();
        bullet.SetDestination(location,CalculateArc(location));
    }



    protected virtual Vector3 CalculateArc(Vector3 destination)
    {
        float gravity = Physics.gravity.magnitude;
        float angle = CalculateAngle() * Mathf.Deg2Rad;

        Vector3 planarTarget = new Vector3(destination.x, 0, destination.z);

        float distance = Vector3.Distance(planarTarget, planarPosition);
        float yOffset = position.y - destination.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPosition);
        if (destination.x < position.x)
            angleBetweenObjects = -angleBetweenObjects;
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        return finalVelocity;
    }

    protected virtual float CalculateAngle()
    {
        return initialAngle / towerSO.bulletSpeed;
    }

}
