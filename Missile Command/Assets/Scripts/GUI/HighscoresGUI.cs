using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoresGUI : MonoBehaviour {
    void Awake()
    {

        generateHighscoreAsList();


    }
    // Use this for initialization
    void Start () {
        Cursor.visible= true;
    }
	
public void backToMenu()
    {
        LevelGenerator.Instance.showStartScreen();

    }

    void generateHighscoreAsList()
    {
        var highscorelist = HighScoreManager.Instance.GetHighScore();
        //var places = GameObject.Find("Places").GetComponent<Text>();
        var names= GameObject.Find("Names").GetComponent<Text>();
        var scores = GameObject.Find("Scores").GetComponent<Text>();

        //places.text = "";
        names.text = "";
        scores.text ="";

        //var place = 0;
        foreach (Scores _score in highscorelist)
        {
           // place++;
           //   places.text += place + ".\n";
            names.text += _score.name + "\n";
            scores.text += _score.score + "\n";
        }



    }

}
