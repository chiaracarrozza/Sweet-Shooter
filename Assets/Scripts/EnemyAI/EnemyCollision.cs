using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameOverandClearMenu menu;
    [SerializeField] Text GameOver;


    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Dessert"))
        {
           

            GameOver.text = "You Lose!";
            menu.gameObject.SetActive(true);
        }
    }

   
    
}
