using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generateHighscoreList : MonoBehaviour {

    // Use this for initialization
    void Start() {
        HighScoreManager.Instance.ClearLeaderBoard();
        HighScoreManager.Instance.SaveHighScore("abc", 1000);
        HighScoreManager.Instance.SaveHighScore("fds", 23433);
        HighScoreManager.Instance.SaveHighScore("fdfe", 23545);
        HighScoreManager.Instance.SaveHighScore("gtd", 234);
        generateHighscoreAsList();

    }



    void generateHighscoreAsList()
    {
        var highscorelist = HighScoreManager.Instance.GetHighScore();

        var Text ="";
        
        foreach (Scores _score in highscorelist)
        {
            Text+= _score.name+ "\t\t\t\t\t" + _score.score+ "\n";
           
        }
        gameObject.GetComponent<Text>().text = Text;

     

    }
}