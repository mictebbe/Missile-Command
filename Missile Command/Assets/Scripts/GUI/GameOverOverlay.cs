using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverOverlay : MonoBehaviour {
    Text canvas;
   
    public RawImage blendPlane;
    int drawDepth = -1000;
    float alpha = 1;
    Color ColorA = new Color(0, 0, 0, 0);
    Color ColorB = new Color(0, 0, 0, 1);
    // Use this for initialization
    void Start () {
        canvas = gameObject.GetComponent<Text>();
        canvas.enabled=false;
    }
	
	
	void Update () {
        if (!GameManager.Instance.hasGameEnded())
            return;
        {
          
           StartCoroutine(endGame());
           
        }
	}


    //called by End Game Button
    IEnumerator endGame()
    {
        canvas.enabled = true;
        //blend();
        yield return new WaitForSeconds(3);

        LevelGenerator.Instance.showEndScreen();
    }

    IEnumerator blendScreen()
    {
        //Color blendPlane = gameObject.transform.Find("BlendPlane").gameObject.GetComponent<RawImage>().color;
        for (float f = 0; f <= 1.0f; f += 0.04f)
        {

            blendPlane.color = Color.Lerp(ColorA,ColorB,f);
           
            //blendPlane = f;
            Debug.Log(f);
            yield return null;
        }
    }

    
}
