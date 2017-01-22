using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StartScreenGUI : MonoBehaviour
{

    public void startGame()
    {

       
        GameManager.Instance.startNewGame();


    }

    public void showHighscores()
    {


        LevelGenerator.Instance.showHighscores();


    }

    public void showOptions()
    {


        LevelGenerator.Instance.showOptions();


    }


  
 
 

}
