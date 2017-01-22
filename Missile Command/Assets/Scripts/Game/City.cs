using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class City : MonoBehaviour {

	public GameObject explosionPrefab;
    public List<AudioClip> sounds=new List<AudioClip>();
    public AudioClip explosionSound1;
    public AudioClip explosionSound2;
    public AudioClip explosionSound3;
    private Light levelStartLight;
    AudioSource audio;
    void Start () {
        levelStartLight = gameObject.transform.FindChild("Directional light").GetComponent<Light>();
        levelStartLight.enabled = false;
        levelStartLight.intensity = 0;
        audio = GetComponent<AudioSource>();
        sounds.Add(explosionSound1);
        sounds.Add(explosionSound2);
        sounds.Add(explosionSound3);
        if (GameManager.Instance.isCityDestroyed(this.gameObject)) {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            StartCoroutine(levelStartLights());
        }

		explosionPrefab = Instantiate(explosionPrefab) as GameObject;
		explosionPrefab.transform.parent = gameObject.transform;
		explosionPrefab.transform.localPosition = new Vector3(0, 0, 0);
		explosionPrefab.SetActive(false);
	}
	
	void Update () {
		// ...
	}

	void Explode()
	{
		

		if (GameManager.Instance.isDestroyed())
		{
			GameManager.Instance.endGame();
		}
        if (!GameManager.Instance.isCityDestroyed(this.gameObject))
        {
            GameManager.Instance.destroyCity(gameObject);
            // Change model to destroyed building
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            explosionPrefab.SetActive(true);
            var idx = Mathf.FloorToInt(UnityEngine.Random.Range(0, 2.99f));
            audio.clip = sounds[idx];
            audio.Play();

            
        }
    }

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "MissileEnemy(Clone)" )
		{
			Explode();
		}
	}

    IEnumerator levelStartLights()
    {
       
        for (int j = 0; j < 2; j++) {
            levelStartLight.enabled = true;
            for (float i = 0.0f; i < 8; i += 1.5f)
            {
               
                levelStartLight.intensity = i;
               yield return null;
            }


            yield return new WaitForSeconds(0.3f);
            levelStartLight.enabled = false;
            Debug.Log("   " + j);
            yield return new WaitForSeconds(0.3f);
        }




    }
}
