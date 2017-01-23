using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private string scoreText;
    private Text guiText;
   
    // Use this for initialization
    void Start () {
        scoreText =""+ GameManager.Instance.getScore();
        gameObject.GetComponent<Text>().text = scoreText;
        var guiText = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.hasScoreChanged())
        {
            scoreText =""+ GameManager.Instance.getScore();

            gameObject.GetComponent<Text>().text =  scoreText;
        }
    }
}
