using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour {


	private ParticleSystem ps;
	private CapsuleCollider co;

	public AudioClip explosion;
	
	void Start () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = explosion;
		audio.Play();

		var child = transform.GetChild(0);
		ps = child.GetComponent<ParticleSystem>();
		co = child.GetComponent<CapsuleCollider>();
	}
	
	void Update () {
		if (co.radius > 0.0f)
			co.radius -= 0.4f;
	}
}
