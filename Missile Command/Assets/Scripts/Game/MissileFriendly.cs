﻿using UnityEngine;
using System.Collections;

public class MissileFriendly : MonoBehaviour
{
	public GameObject missilePrefab;
	public GameObject explosionPrefab;
	public Vector3 targetPosition;

	public float noiseAmp = 0;
	public float noiseScale = 0;

	public float speed = 3.0f;

	private Vector3 direction;
	private GameObject explosion;
	private bool once = true;

	void Start()
	{
		explosion = Instantiate(explosionPrefab) as GameObject;
		explosion.transform.parent = gameObject.transform;
		explosion.transform.localPosition = new Vector3(0, 0, 0);
		explosion.SetActive(false);
	}

	void Update()
	{
		StartCoroutine(Fly());
	}

	IEnumerator Fly()
	{
		var position = gameObject.transform.position;
		if (Vector3.Distance(position, targetPosition) > 3.0f)
		{
			var path = targetPosition - position;
			direction = Vector3.Normalize(path);

			var noise = noiseAmp * (Mathf.PerlinNoise(path.x * noiseScale, path.y * noiseScale) - 0.5f);
			var side = new Vector3(0, 0, 1);
			var modDirection = Vector3.Cross(direction, side);

			var translation = (direction * speed) + (modDirection * noise);

			gameObject.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(-translation);
			gameObject.transform.Translate(translation);
		} else if(once)
		{
			once = false;
			Explode();
		}
		yield return null;
	}

	void Explode()
	{
		explosion.SetActive(true);
		transform.GetChild(0).gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider other)
	{
		Explode();
	}
}
