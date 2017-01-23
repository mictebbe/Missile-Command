using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class StartScreenGUI : MonoBehaviour
{

    void Start()
    {
        GameObject.Find("Loading").GetComponent<Text>().enabled = false;
        HighScoreManager.Instance.SaveHighScore("Michi", 100);
        HighScoreManager.Instance.SaveHighScore("Tarek", 200);

    }

    public void startGame()
    {

        GameManager.Instance.startNewGame();
        GameObject.Find("New Game").GetComponent<Text>().enabled = false;
        GameObject.Find("HighscoresText").GetComponent<Text>().enabled = false;
        GameObject.Find("OptionsText").GetComponent<Text>().enabled = false;


        GameObject.Find("Loading").GetComponent<Text>().enabled = true;
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
