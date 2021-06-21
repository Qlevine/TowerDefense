using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletBaseClass : MonoBehaviour
{
    [SerializeField]
    protected BulletSO bulletSO;

    protected Vector3 destination;

    [SerializeField]
    protected Rigidbody rb;
    public void SetDestination(Vector3 destination, Vector3 velocity)
    {
        this.destination = destination;
        rb.AddForce(velocity * rb.mass, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
