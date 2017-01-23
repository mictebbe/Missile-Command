using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsGUI : MonoBehaviour {

    Slider slider;

    void Start()
    {
        Cursor.visible = true;
        slider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        slider.value = AudioListener.volume;

    }
	public void backToMenu()
    {
        LevelGenerator.Instance.showStartScreen();

    }

    public void clearLeaderboard()
    {
        HighScoreManager.Instance.ClearLeaderBoard();
    }

    public void setVolume()
    {
       
       
        AudioListener.volume = slider.value;

    }
}
