using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    Rigidbody rb;
    int hitCount = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BULLET"))
        {
            hitCount++;
            if (hitCount == 3)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, 1 << 8);

                foreach (var collider in colliders)
                {
                    var _rb = collider.GetComponent<Rigidbody>();
                    _rb.mass = 1f;
                    _rb.AddExplosionForce(1200f, transform.position, 15f, 1000f);
                }
            }
        }
    }

    void Update()
    {
        
    }
}
