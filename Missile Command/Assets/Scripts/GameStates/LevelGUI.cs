using UnityEngine;
using System.Collections;

public class LevelGUI : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        print("Loaded: " + GameManager.instance.getLevel());
    }

    // Update is called once per frame
    void Update () {
	
	}

    // ---------------------------------------------------------------------------------------------------
    // OnGUI()
    // --------------------------------------------------------------------------------------------------- 
    // Provides a GUI on level scenes
    // ---------------------------------------------------------------------------------------------------
    void OnGUI()
    {
        // Create buttons to move between level 1 and level 2
        if (GUI.Button(new Rect(30, 30, 150, 30), "Back to Main Menu"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Gamestart");


        }

        if (GUI.Button(new Rect(300, 30, 150, 30), "Next Level"))
        {
            print("Moving to level 2");
            GameManager.Instance.addLevel();
            GameManager.Instance.levelGenerator.generateLevel(1);

        }
    }

}
