using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //Making the Strawberry Bullet destroy only the objects with the "Target" tag, so all the boxes.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    
}
