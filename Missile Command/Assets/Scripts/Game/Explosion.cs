using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	private ParticleSystem ps;

	void Start () {
		ps = GetComponentInChildren<ParticleSystem>();
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
