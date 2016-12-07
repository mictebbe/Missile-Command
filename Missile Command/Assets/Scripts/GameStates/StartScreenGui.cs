using UnityEngine;
using System.Collections;

public class StartScreenGui : MonoBehaviour {

    void Awake()
    {



    }
    // Our Startscreen GUI
    void OnGUI()
    {

        if (GUI.Button(new Rect(Screen.width/2, Screen.height / 2, 150, 30), "Start Game"))
        {
            startGame();
        }
    }



    private void startGame()
    {
        print("Starting game");

       DontDestroyOnLoad(GameManager.instance);
        DontDestroyOnLoad(LevelGenerator.instance);
        GameManager.Instance.startState();
        Debug.Log("startGame() "+GameManager.Instance.getLevel());
        GameManager.Instance.initLevel();
        
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
