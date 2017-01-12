using UnityEngine;
using System.Collections;

public class friendlyMissileScript : MonoBehaviour
{
	public float speed = 1;
	public GameObject cursor;
	public GameObject friendlyExplosionPrefab;
	private Vector3 direction;
	private GameObject parent;
	private Vector3 explosionPosition;
	private GameObject friendlyExplosion;
	// Use this for initialization
	void Start()
	{

		explosionPosition = cursor.transform.position;
	

		Debug.Log("Explosion position: " + explosionPosition);
		Debug.Log("Direction: " + direction);

		friendlyExplosion = Instantiate(friendlyExplosionPrefab) as GameObject;
		//friendlyExplosion.transform.localScale = new Vector3(1, 1, 1);
		friendlyExplosion.transform.position = explosionPosition;
		friendlyExplosion.SetActive(false);

		if (friendlyExplosion.GetComponent<ExplosionScript>() == null)
		{
			friendlyExplosion.AddComponent<ExplosionScript>();
		}

	}

	// Update is called once per frame
	void Update()
	{

		StartCoroutine(Fly());

		if (Vector3.Magnitude(gameObject.transform.position - explosionPosition) <= 2 * speed)
		{

			Debug.Log("Friendly Missile explodes.");
			friendlyExplosion.SetActive(true);
			Destroy(gameObject);

		}
	}


	IEnumerator Fly()
	{
		var amplitude = 4.0f;
		var speedMod = 0.7f; // redundant
		var scale = 0.006f;

		var missilePosition = gameObject.transform.position;
		var path = explosionPosition - missilePosition;
		direction = Vector3.Normalize(path);

		var translation = direction * speed * speedMod;
		var noise = amplitude *  (Mathf.PerlinNoise(path.x * scale, path.y * scale) - 0.5f);

		var side = new Vector3(0, 0, 1);
		var modDirection = Vector3.Cross(direction, side);
		translation += modDirection * noise;

		gameObject.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(-translation);
		gameObject.transform.Translate(translation);

		yield return null;
	}
}
