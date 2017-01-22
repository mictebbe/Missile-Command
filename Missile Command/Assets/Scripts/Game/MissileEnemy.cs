﻿using UnityEngine;
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
    AudioLowPassFilter lowPass ;
    Vector3 initialPosition;
    // Use this for initialization
    void Start()
	{
        AudioSource audio = GetComponent<AudioSource>();
        lowPass = GetComponent<AudioLowPassFilter>();
        var idx = UnityEngine.Random.Range(-2.0f, 1.0f);
        audio.pitch = 1;// idx;
        audio.Play();
        explosion = Instantiate(explosionPrefab) as GameObject;
		explosion.transform.parent = gameObject.transform;
		explosion.transform.localPosition = new Vector3(0, 0, 0);
		explosion.SetActive(false);
        initialPosition = gameObject.transform.position;

        lowPass.lowpassResonanceQ = 2.0f;
    }
	
	void Update ()
	{
        if(moving)
        {
                  var position = gameObject.transform.position;
            
           
                  var distance = Vector3.Distance(position, targetPosition);
                  if (distance > 10.0f)
                  {
                      var path = targetPosition - position;
                      var direction = Vector3.Normalize(path);
                              var noise = noiseAmp * (Mathf.PerlinNoise(path.x * noiseScale, path.y * noiseScale) - 0.5f);
                      var side = new Vector3(0, 0, 1);
                      var modDirection = Vector3.Cross(direction, side);

                      translation = direction + (modDirection * noise);

                      gameObject.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(-translation);
                  }

                  gameObject.transform.Translate(translation * speed*Time.deltaTime);
            
            
            
            lowPass.cutoffFrequency = Mathf.Lerp( 0,22000, 1-(position-targetPosition).magnitude/ (initialPosition - targetPosition).magnitude);
            //Debug.Log(lowPass.cutoffFrequency );
        }
        //if (moving) {

        //    StartCoroutine(Fly());
        //}
	}

	IEnumerator Fly()
	{		
		var position = gameObject.transform.position;
        var initialDistance = Vector3.Distance(position, targetPosition);
        var currentDistance = initialDistance;
        while (currentDistance > -10)
		{
			var path = targetPosition - position;
			var direction = Vector3.Normalize(path);

			var noise = noiseAmp * (Mathf.PerlinNoise(path.x * noiseScale, path.y * noiseScale) - 0.5f);
			var side = new Vector3(0, 0, 1);
			var modDirection = Vector3.Cross(direction, side);

			translation = direction + (modDirection * noise);

			gameObject.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(-translation);
            position = Vector3.MoveTowards(position + (modDirection * noise), targetPosition, speed * Time.deltaTime);
            gameObject.transform.position = position;
            
            lowPass.cutoffFrequency = Mathf.Lerp(22000,0, currentDistance/initialDistance);
            Debug.Log(lowPass.cutoffFrequency);
            //Debug.Log(Vector3.Distance(position, targetPosition));
            currentDistance = Vector3.Distance(position, targetPosition);
            yield return null;
            
        } 
		
		//gameObject.transform.Translate(translation * speed);
		
		
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
        Destroy(gameObject);
		//gameObject.transform.GetChild(0).gameObject.SetActive(false); // disable missile
		//GameManager.Instance.EnemyMissilesLiving -= 1;
	}

	void OnTriggerEnter(Collider collider)
	{
		var name = collider.gameObject.name;
		if (name != "CursorPlane" && name != "MissileEnemy(Clone)" && name != "Cursor")
		{
			Explode();
		}

	}

}
