using UnityEngine;
using System.Collections;

public class MissileEnemy : MonoBehaviour {

	public GameObject missilePrefab;
	public GameObject explosionPrefab;
	public Vector3 targetPosition;

	public float noiseAmp = 0.0f;
	public float noiseScale = 0.0f;

	public float speed = 1.0f;
	
	private Vector3 translation;
	private GameObject explosion;
	private bool moving = true;

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
		if(moving)
		{
			StartCoroutine(Fly());
		}
	}

	IEnumerator Fly()
	{		
		var position = gameObject.transform.position;

		if(Vector3.Distance(position, targetPosition) > 10.0f)
		{
			var path = targetPosition - position;
			var direction = Vector3.Normalize(path);

			var noise = noiseAmp * (Mathf.PerlinNoise(path.x * noiseScale, path.y * noiseScale) - 0.5f);
			var side = new Vector3(0, 0, 1);
			var modDirection = Vector3.Cross(direction, side);

			translation = direction + (modDirection * noise);

			gameObject.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(-translation);
		} 
		
		gameObject.transform.Translate(translation * speed);
		
		yield return null;
	}

	public void Fire(Vector3 target)
	{
		targetPosition = target;
		translation = Vector3.Normalize(targetPosition - gameObject.transform.position);
		gameObject.SetActive(true);
	}

	public void Explode()
	{
		moving = false;
		explosion.SetActive(true);
		gameObject.transform.GetChild(0).gameObject.SetActive(false); // disable missile
		//GameManager.Instance.EnemyMissilesLiving -= 1;
	}

	void OnTriggerEnter(Collider collider)
	{
		Explode();
	}

}
