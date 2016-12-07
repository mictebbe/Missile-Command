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
        if (GUI.Button(new Rect(30, 30, 150, 30), "Load next Level"))
        {
            GameManager.instance.addLevel();
            Application.LoadLevel("level1");
            
        }

        if (GUI.Button(new Rect(300, 30, 150, 30), "Load Start screen"))
        {
            print("Moving to level 2");
            //gamestate.Instance.setLevel("Level 2");
           // Application.LoadLevel("level2");
        }
    }

}
