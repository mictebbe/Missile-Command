using UnityEngine;
using System.Collections;

public class MissileSpawnerFriendly : MonoBehaviour
{
	public GameObject missilePrefab;
	public GameObject explosionPrefab;

	public UnityEngine.KeyCode buttonNumber = KeyCode.A;
	public GameObject cursor;

	private Vector3 target;
	private int loadedMissles = 10;
	private float speed = 1.0f;

	private Stack missiles = new Stack();

	void Start()
	{
		cursor = GameObject.Find("PlayerControls").GetComponent<MouseControls>().cursor;

		/*** Init Missiles *******************************************************/
		for (int i = 0; i <= loadedMissles; i++)
		{
			GameObject missile = Instantiate(missilePrefab) as GameObject;
			missile.transform.parent = GameObject.Find("Missiles").transform;
			missile.AddComponent<MissileScriptFriendly>();

			var missileScript = missile.GetComponent<MissileScriptFriendly>();
			missileScript.missilePrefab = missilePrefab;
			missileScript.explosionPrefab = explosionPrefab;
			missileScript.transform.position = transform.position;
			missileScript.speed = speed;
			missileScript.noiseAmp = 4.0f;
			missileScript.noiseScale = 0.006f;

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
					GameObject missile = (GameObject)missiles.Pop();
					missile.GetComponent<MissileScriptFriendly>().targetPosition = cursor.transform.position;
					missile.SetActive(true);
					
				}
				else
				{
					Debug.Log("No missiles left in Missile Launcher '" + gameObject.name + "'");
				}		
		}
	}	
}
