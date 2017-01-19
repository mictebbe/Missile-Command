using UnityEngine;
using System.Collections;
using UnityEngine.Events;


public class StartScreenGui : UnityEvent<string>
{

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



    public void startGame()
    {

      
        GameManager.Instance.startNewGame();
        
        
    }

    // Use this for initialization
    void Start () {
       
    }
	
	

}
