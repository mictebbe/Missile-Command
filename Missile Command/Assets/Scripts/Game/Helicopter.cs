using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour
{
	public GameObject ExplosionPrefab;
	private GameObject explosion;
	private Vector3 startPos;
	private float speed = 1.0f;
	private bool flying = false;
	private float startTime = 0;
	// Use this for initialization
	void Start()
	{

		explosion = Instantiate(ExplosionPrefab) as GameObject;
		explosion.transform.localPosition = gameObject.transform.localPosition;
		explosion.SetActive(false);
		startPos = transform.position;

		AudioSource audio = GetComponent<AudioSource>();
		startTime = Random.Range(0, 5);

		if (GameManager.Instance.getLevel() % 5 == 0)
		{
			flying = true;
			audio.Play();
		}
	}

	// Update is called once per frame
	void Update()
	{
		StartCoroutine(Fly());
	}

	public void Explode()
	{
		if (explosion != null)
		{
			explosion.transform.position = gameObject.transform.position;
		}
		explosion.SetActive(true);
		Debug.Log("Heli hit!");
		Destroy(gameObject);

	}

	IEnumerator Fly()
	{


		yield return new WaitForSeconds(startTime);
		while (flying)
		{
			transform.position += transform.forward * (-0.5f) * Time.deltaTime;

			var noise = 0.001f * (Mathf.PerlinNoise(Time.time * 0.12f, 0) - 0.5f);
			transform.Rotate(new Vector3(0, 0, noise));

			transform.Find("main_rotor").transform.Rotate(new Vector3(0, 0, 15));

			if (transform.position.x > 400.0)
			{
				transform.position = startPos;
				this.enabled = false;
				flying = false;
			}
			yield return null;

		}

	}
}
