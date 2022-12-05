using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LemonCollider : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
             Destroy(gameObject);
        }
 
    }

    private void Update()
    {
        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }




}
