using UnityEngine;
using System.Collections;

public class EndScreenGui : MonoBehaviour {

    void OnGUI()
    {

        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 150, 30), "Restart Game"))
        {
            restartGame();
        }
    }

    private void restartGame()
    {
     
        print("Restarting game");

        //DontDestroyOnLoad(GameManager.instance);
        //DontDestroyOnLoad(LevelGenerator.instance);
        GameManager.Instance.startState();
        //Debug.Log("startGame() " + GameManager.Instance.getLevel());
        GameManager.Instance.initLevel();
        

}
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
