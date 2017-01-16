using UnityEngine;
using System.Collections;

public class EndScreenGui : MonoBehaviour {

    void OnGUI()
    {
        
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 150, 30), "Restart"))
        {
            restartGame();
        }

        if (GUI.Button(new Rect(Screen.width / 2, 50 + Screen.height / 2, 150, 30), "Menu"))
        {
            backToMenu();
        }
    }

    private void restartGame()
    {
     
        
        GameManager.Instance.startNewGame();
        

}

    private void backToMenu()
    {

        print("Back to Menu");

        //DontDestroyOnLoad(GameManager.instance);
        //DontDestroyOnLoad(LevelGenerator.instance);
        GameManager.Instance.goToMenu();
        
        


    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
