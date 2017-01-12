using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {
    public GameObject ExplosionPrefab;
    private GameObject explosion;
    private Vector3 startPos;
	private float speed = 1.0f;

	// Use this for initialization
	void Start () {

        explosion = Instantiate(ExplosionPrefab) as GameObject;
        explosion.transform.localPosition = gameObject.transform.localPosition;
        explosion.SetActive(false);
        startPos = transform.position;

		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();

	}
	
	// Update is called once per frame
	void Update () {

		transform.position += transform.forward * (-2.0f);
	
		var noise = 2.0f * (Mathf.PerlinNoise(Time.time * 0.3f, 0) - 0.5f);
		transform.Rotate(new Vector3(0, 0, noise));

		transform.Find("main_rotor").transform.Rotate(new Vector3(0, 0, 15));
		
		if(transform.position.x > 400.0)
		{
			transform.position = startPos;
			this.enabled = false;
		}

      

    }

    public void Explode()
    {
        if (explosion != null)
        {
            explosion.transform.position= gameObject.transform.position;
        }
        explosion.SetActive(true);
        Debug.Log("Heli hit!");
        Destroy(gameObject);

    }
}
