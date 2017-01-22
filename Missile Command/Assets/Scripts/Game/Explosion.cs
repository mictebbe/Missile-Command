using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour {

	private ParticleSystem ps;

	public AudioClip explosion;

	void Start () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = explosion;
		audio.Play();
	}
	
	void Update () {
	
	}
}
