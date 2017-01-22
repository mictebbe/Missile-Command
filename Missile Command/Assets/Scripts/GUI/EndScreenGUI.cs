using UnityEngine;
using System.Collections;

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

        LevelGenerator.Instance.showHighscores();
    }
}
