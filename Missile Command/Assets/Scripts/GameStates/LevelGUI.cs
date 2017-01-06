using UnityEngine;
using System.Collections;

public class LevelGUI : MonoBehaviour {
    public int scoreText;
    // Use this for initialization
    void Start()
    {
        scoreText = GameManager.Instance.getScore();
        print("Loaded: " + GameManager.instance.getLevel());
    }

    // Update is called once per frame
    void Update () {
        scoreText = GameManager.Instance.getScore();

       
        //
    }

    // ---------------------------------------------------------------------------------------------------
    // OnGUI()
    // --------------------------------------------------------------------------------------------------- 
    // Provides a GUI on level scenes
    // ---------------------------------------------------------------------------------------------------
    void OnGUI()
    {

        GUI.Label(new Rect(new Vector2(10.0f, 10.0f), new Vector2(1000.0f, 1000.0f)), "" + scoreText);
        // Create buttons to move between level 1 and level 2
        if (GUI.Button(new Rect(30, 30, 150, 30), "Back to Main Menu"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Gamestart");


        }

        if (GUI.Button(new Rect(300, 30, 150, 30), "Next Level"))
        {
            print("Moving from level "+GameManager.Instance.getLevel());
            GameManager.Instance.addLevel();
            print("Moving to level " + GameManager.Instance.getLevel());
            GameManager.Instance.initLevel();

        }
    }

}
