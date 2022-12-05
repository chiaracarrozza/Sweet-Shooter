using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] float ExplosingForce;

    [SerializeField] float ExplosionRadius;

    [SerializeField] float UpwardsModifier;

   //SphereCast to make the explosion happen when the player touches the trap
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dessert"))
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, ExplosionRadius, transform.right, ExplosionRadius);
            foreach(RaycastHit hit in hits)
            {
                if (hit.collider.CompareTag("Dessert"))
                {
                    hit.rigidbody.AddExplosionForce(ExplosingForce, transform.position, ExplosionRadius, UpwardsModifier, ForceMode.Force);
                    
                }
            }
        }

    }

}
