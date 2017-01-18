using UnityEngine;
using System.Collections;

public class MissileSpawnerFriendly : MonoBehaviour
{
	public GameObject missilePrefab;
	public GameObject explosionPrefab;
	public GameObject selfExplosion;

	public UnityEngine.KeyCode buttonNumber = KeyCode.A;
	public GameObject cursor;

	private Vector3 target;
	private int loadedMissles = 10;
	private float speed = 4.0f;

	private Stack missiles = new Stack();

	void Start()
	{
		cursor = GameObject.Find("PlayerControls").GetComponent<MouseControls>().cursor;

		selfExplosion = Instantiate(selfExplosion) as GameObject;
		selfExplosion.transform.parent = gameObject.transform;
		selfExplosion.transform.localPosition = new Vector3(0, 0, 0);
		selfExplosion.SetActive(false);

		/*** Init Missiles *******************************************************/
		for (int i = 0; i < loadedMissles; i++)
		{
			GameObject missile = Instantiate(missilePrefab) as GameObject;
			missile.transform.parent = GameObject.Find("Missiles").transform;
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
		if (Input.GetKeyDown(buttonNumber) && !GameManager.Instance.isDestroyed())
		{
				if (missiles.Count > 0)
				{
					GameObject missile = (GameObject) missiles.Pop();
					missile.GetComponent<MissileFriendly>().targetPosition = cursor.transform.position;
					missile.SetActive(true);			
				}
				else
				{
					Debug.Log("No missiles left in Missile Launcher '" + gameObject.name + "'");
				}		
		}
	}

	void Explode()
	{
		selfExplosion.SetActive(true);
		transform.GetChild(0).gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name != "Terrain")
		{
			Explode();
		}
	}
}
