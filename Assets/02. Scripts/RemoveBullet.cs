using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("BULLET"))
        { //collision.gameObject.CompareTag("BULLET")
            Destroy(collision.gameObject);
        }
    }
}
