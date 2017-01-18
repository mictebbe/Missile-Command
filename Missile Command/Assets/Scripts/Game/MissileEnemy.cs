using UnityEngine;
using System.Collections;

public class MissileEnemy : MonoBehaviour {

	public GameObject missilePrefab;
	public GameObject explosionPrefab;
	public Vector3 targetPosition;

	public float noiseAmp = 0.0f;
	public float noiseScale = 0.0f;

	public float speed = 4.0f;
	
	private Vector3 direction;
	private GameObject explosion;

	// Use this for initialization
	void Start()
	{
		explosion = Instantiate(explosionPrefab) as GameObject;
		explosion.transform.parent = gameObject.transform;
		explosion.transform.localPosition = new Vector3(0, 0, 0);
		explosion.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		StartCoroutine(Fly());
	}

	IEnumerator Fly()
	{
		var path = targetPosition - gameObject.transform.position; 
		direction = Vector3.Normalize(path);

		var noise = noiseAmp * (Mathf.PerlinNoise(path.x * noiseScale, path.y * noiseScale) - 0.5f);
		var side = new Vector3(0, 0, 1);
		var modDirection = Vector3.Cross(direction, side);

		var translation = (direction * 3.0f) + (modDirection * noise);

		gameObject.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(-translation);
		gameObject.transform.Translate(translation);
		
		yield return null;
	}


	public void Explode()
	{
		Destroy(gameObject);
		explosion.SetActive(true);
		//GameManager.Instance.EnemyMissilesLiving -= 1;
	}

	void OnTriggerEnter(Collider other)
	{
		Explode();
		Debug.Log("Explode");
	}

}
