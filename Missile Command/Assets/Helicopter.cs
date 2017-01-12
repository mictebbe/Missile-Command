using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	private Vector3 startPos;
	private float speed = 1.0f;

	// Use this for initialization
	void Start () {
		startPos = transform.position;

		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();

	}
	
	// Update is called once per frame
	void Update () {

		transform.position += transform.forward * (-2.0f);

		transform.Find("main_rotor").transform.Rotate(new Vector3(0, 0, 15));
		
		if(transform.position.x > 400.0)
		{
			transform.position = startPos;
			this.enabled = false;
		}
		
	}
}
