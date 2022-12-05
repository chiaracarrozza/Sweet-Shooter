using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int CurrentCandies;
    public Text CandiesText;

    [SerializeField] Text Cleared;
    [SerializeField] GameOverandClearMenu menu;

    // Update is called once per frame
    void Update()
    { //Goal Achived
        if(CurrentCandies == 6)
        {
            Cleared.text = "Game Cleared!";
            menu.gameObject.SetActive(true);
        }
        
    }
    //Adds the number of candies collected in the top right corner of the screen
    public void AddCandies(int CandiesToAdd)
    {
        CurrentCandies += CandiesToAdd;
        CandiesText.text = "Candies: " + CurrentCandies;
    }
    
    
    
}
