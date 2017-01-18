﻿using UnityEngine;
using System.Collections;

public class MissileSpawnerEnemy : MonoBehaviour
{
	public GameObject missilePrefab;
	public GameObject explosionPrefab;

	private GameObject target;
	private int loadedMissles = 10;
	private float speed = 10.0f;
	
	private Stack missiles = new Stack();
	private ArrayList targets = new ArrayList();
	
	// Use this for initialization
	void Start ()
	{
		/*** Init Targets *******************************************************/
		var cities = GameObject.Find("Cities").transform;
		for (var i = 0; i < cities.childCount; ++i)
		{
			GameObject city = cities.GetChild(i).gameObject;
			targets.Add(city);
		}

		var missileLauncher = GameObject.Find("MissileLauncher").transform;
		for (var i = 0; i < missileLauncher.childCount; ++i)
		{
			GameObject mL = missileLauncher.GetChild(i).gameObject;
			targets.Add(mL);
		}

		/*** Init Missiles *******************************************************/
		this.speed = GameManager.Instance.getLevel() * 0.6f;
		for (int i = 0; i < loadedMissles; i++)
		{
			GameObject missile = Instantiate(missilePrefab) as GameObject;
			missile.transform.parent = GameObject.Find("Missiles").transform;
			missile.AddComponent<MissileEnemy>();

			var missileScript = missile.GetComponent<MissileEnemy>();
			missileScript.missilePrefab = missilePrefab;
			missileScript.explosionPrefab = explosionPrefab;
			missileScript.transform.position = transform.position;
			missileScript.speed = speed;
			missileScript.noiseAmp = 0.5f;
			missileScript.noiseScale = 0.001f;

			missile.SetActive(false);
			missiles.Push(missile);
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.frameCount % 60 == 0 && !GameManager.Instance.isDestroyed())
		{
			if (missiles.Count > 0)
			{
				changeTarget();

				GameObject missile = (GameObject) missiles.Pop();
				missile.transform.Translate(new Vector3(Random.Range(-100, 100), 0, 0));

				missile.GetComponent<MissileEnemy>().targetPosition = target.transform.position;
				missile.SetActive(true);
			}
			else
			{
				Debug.Log("No missiles left in Missile Launcher '" + gameObject.name + "'");
			}
		}

	}

	public void changeTarget()
	{
		target = (GameObject)targets[(int)Mathf.Floor(Random.Range(0, targets.Count))];
	}

	public void removeTarget(GameObject target)
	{
		if (targets.Contains(target))
		{
			targets.Remove(target);
		}
	}
}