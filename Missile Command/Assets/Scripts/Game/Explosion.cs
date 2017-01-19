using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour {

	private ParticleSystem ps;

	public AudioClip explosion1;
	public AudioClip explosion2;
	public AudioClip explosion3;

	void Start () {
		ps = GetComponentInChildren<ParticleSystem>();
	
		var idx = Mathf.FloorToInt(UnityEngine.Random.Range(0, 2.99f));
		List<AudioClip> sounds = new List<AudioClip>();
		sounds.Add(explosion1);
		sounds.Add(explosion2);
		sounds.Add(explosion3);

		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = sounds[idx];
		audio.Play();
	}
	
	void Update () {
		if (ps)
		{
			if (!ps.IsAlive())
			{
				Destroy(transform.parent.gameObject);	
			}
		}
	}
}
