using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessingEffects : MonoBehaviour {
    float SkyboxSpeed = 100f;
    // Use this for initialization
    void Start () {
       StartCoroutine(TweakBloomThreshold());
        //StartCoroutine(TweakSkyboxRotation());
    }
	
	// Update is called once per frame
	void Update () {
        
        
	}

    IEnumerator TweakBloomThreshold()
    {
        while (true)
        {
            gameObject.GetComponent<BloomAndLensFlares>().bloomThreshhold = Mathf.Sin(Time.fixedTime / 10) * .1f + 0.9f;

            yield return null;
        }


    }
    IEnumerator TweakSkyboxRotation() 
        {
            while (true)
            {
              //  gameObject.GetComponent<Skybox>().material.SetFloat("_Rotation", Time.time * SkyboxSpeed);

                yield return null;
            }


        }
    
}
