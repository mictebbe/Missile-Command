using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartOverlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var Text = "Level " + GameManager.Instance.getLevel();
        var guiText = gameObject.GetComponent<Text>();
        guiText.text = Text;
        gameObject.SetActive(true);
        StartCoroutine(ShowOverlay());
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator ShowOverlay()
    {
       //

       
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
        
    }
}
