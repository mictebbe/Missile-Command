using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoresGUI : MonoBehaviour {
    void Awake()
    {
        
       

    }
    // Use this for initialization
    void Start () {
        
    }
	
public void backToMenu()
    {
        LevelGenerator.Instance.showStartScreen();

    }


}
