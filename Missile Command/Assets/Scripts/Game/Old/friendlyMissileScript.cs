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
	

		//Debug.Log("Explosion position: " + explosionPosition);
		//Debug.Log("Direction: " + direction);

		friendlyExplosion = Instantiate(friendlyExplosionPrefab) as GameObject;
		//friendlyExplosion.transform.localScale = new Vector3(1, 1, 1);
		friendlyExplosion.transform.position = explosionPosition;
		friendlyExplosion.SetActive(false);

		if (friendlyExplosion.GetComponent<Explosion>() == null)
		{
			friendlyExplosion.AddComponent<Explosion>();
		}

        if (friendlyExplosion.GetComponent<ExplosionCollision>() == null)
        {
            friendlyExplosion.AddComponent<ExplosionCollision>();
        }

    }

	// Update is called once per frame
	void Update()
	{

		StartCoroutine(Fly());

		if (Vector3.Magnitude(gameObject.transform.position - explosionPosition) <= 2 * speed)
		{

            //Debug.Log("Friendly Missile explodes.");
            if (friendlyExplosion != null)
            {
                friendlyExplosion.SetActive(true);
            }
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
			gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
		}
	}


	IEnumerator Fly()
	{
		var amplitude = 4.0f;
		var scale = 0.006f;

		var missilePosition = gameObject.transform.position;
		var path = explosionPosition - missilePosition;
		direction = Vector3.Normalize(path);

		var translation = direction * speed;
		var noise = amplitude *  (Mathf.PerlinNoise(path.x * scale, path.y * scale) - 0.5f);

		var side = new Vector3(0, 0, 1);
		var modDirection = Vector3.Cross(direction, side);
		translation += modDirection * noise;

		gameObject.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(-translation);
		gameObject.transform.Translate(translation);

		yield return null;
	}
}
