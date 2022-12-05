using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When collding with the candy the player will make it disappear and add it to the candy counter at the right top corner of the screen
public class CandyPickUp : MonoBehaviour
{
    public int values;
   private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Dessert")
        {
            FindObjectOfType<GameManager>().AddCandies(values);
            Destroy(gameObject);
        }
    }
}
