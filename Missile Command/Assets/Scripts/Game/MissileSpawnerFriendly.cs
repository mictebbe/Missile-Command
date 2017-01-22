using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MissileSpawnerFriendly : MonoBehaviour
{
	public GameObject missilePrefab;
	public GameObject explosionPrefab;
	public GameObject selfExplosion;
    public AudioClip launchSound1;
    public AudioClip launchSound2;
    public AudioClip launchSound3;
    public AudioClip launchSound4;
    public AudioClip launchSound5;

    public AudioClip emptySound1;
    public AudioClip emptySound2;

    List<AudioClip> sounds = new List<AudioClip>();
   

		AudioSource audio;
    
    public UnityEngine.KeyCode buttonNumber = KeyCode.A;
	public GameObject cursor;

	private Vector3 target;
	private int loadedMissles = 10;
	private float speed = 200.0f;
	private bool destroyed = false;
	private Transform missileStart;

	private Stack missiles = new Stack();

	void Start()
	{
        audio = GetComponent<AudioSource>();
        sounds.Add(launchSound1);
        sounds.Add(launchSound2);
        sounds.Add(launchSound3);
        sounds.Add(launchSound4);
        sounds.Add(launchSound5);
        sounds.Add(emptySound1);
        sounds.Add(emptySound2);
        cursor = GameObject.Find("PlayerControls").GetComponent<MouseControls>().cursor;
		missileStart = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0);

		selfExplosion = Instantiate(selfExplosion) as GameObject;
		selfExplosion.transform.parent = gameObject.transform;
		selfExplosion.transform.localPosition = new Vector3(0, 0, 0);
		selfExplosion.SetActive(false);

		/*** Init Missiles *******************************************************/
		for (int i = 0; i < loadedMissles; i++)
		{
			GameObject missile = Instantiate(missilePrefab) as GameObject;
			missile.transform.parent = GameObject.Find("MissilesFriendly").transform;
			missile.AddComponent<MissileFriendly>();

			var missileScript = missile.GetComponent<MissileFriendly>();
			missileScript.missilePrefab = missilePrefab;
			missileScript.explosionPrefab = explosionPrefab;

			missileScript.transform.position = transform.position;
			missileScript.speed = speed;
			missileScript.noiseAmp = 1.2f;
			missileScript.noiseScale = 0.008f;

			missile.SetActive(false);
			missiles.Push(missile);
		}
	}


	void Update()
	{
		if (Input.GetKeyDown(buttonNumber) && !GameManager.Instance.isDestroyed() && !destroyed)
		{
				if (missiles.Count > 0)
				{
                 
					GameObject missile = (GameObject) missiles.Pop();
					var missileComponent = missile.GetComponent<MissileFriendly>();
					missileComponent.targetPosition = cursor.transform.position;
					missileComponent.transform.position = missileStart.transform.position;
					missile.SetActive(true);
                var idx = Mathf.FloorToInt(UnityEngine.Random.Range(0, 4.99f));
                audio.clip = sounds[idx];
                audio.Play();
            }
				else
				{
                var idx = Mathf.FloorToInt(UnityEngine.Random.Range(5, 6.99f));
                audio.clip = sounds[idx];
                audio.Play();
            }		
		}
	}

	void Explode()
	{
		destroyed = true;
		selfExplosion.SetActive(true);
		transform.GetChild(0).gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "MissileEnemy(Clone)")
		{
			Explode();
		}
	}
}
