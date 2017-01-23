using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EndScreenGUI : MonoBehaviour {

   
    private void restartGame()
    {
     
        
        GameManager.Instance.startNewGame();
        }

    


    // Use this for initialization
    void Start () {
        Cursor.visible = true;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goToHighscores()
    {
        var playerName = GameObject.Find("PlayerName").GetComponent<Text>().text;
        var score = GameManager.Instance.getScore();
        if (playerName != "")
        {
            HighScoreManager.Instance.SaveHighScore(playerName,score);
            var scores = HighScoreManager.Instance.GetHighScore();
            foreach(Scores a in scores)
            {

                Debug.Log(a.name+"   "+a.score);

            }
            Debug.Log(HighScoreManager.Instance.GetHighScore());
            LevelGenerator.Instance.showHighscores();
        }
        else
        {
            GameObject.Find("InputField").GetComponent<InputField>().Select();

        }
    }

    void saveScore()
    {


    }
}
