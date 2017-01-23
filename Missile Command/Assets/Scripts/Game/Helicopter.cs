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
    AudioSource audioSource;
    // Use this for initialization
    void Start()
	{

		explosion = Instantiate(ExplosionPrefab) as GameObject;
		explosion.transform.localPosition = gameObject.transform.localPosition;
		explosion.SetActive(false);
		startPos = transform.position;

		audioSource = GetComponent<AudioSource>();
		startTime = Random.Range(0, 5);

		if (GameManager.Instance.getLevel() % 1 == 0)
		{
			flying = true;
			audioSource.Play();
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
          
			transform.position += transform.forward * (-0.3f) * Time.deltaTime;
            audioSource.panStereo = map(transform.position.x, startPos.x, 400, -1, 1);

            
            var noise = 0.001f * (Mathf.PerlinNoise(Time.time * 0.12f, 0) - 0.5f);
			transform.Rotate(new Vector3(0, 0, noise));

			transform.GetChild(0).GetChild(0).transform.Rotate(new Vector3(0, 0, 15));

			if (transform.position.x > 400.0)
			{
				transform.position = startPos;
				this.enabled = false;
				flying = false;
                audioSource.Stop();

            }
			yield return null;

		}

	}


    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Exposion-[Explosion4]")
        {
            GameManager.instance.addToScore(ScoreState.missileDestroyed);
            Explode();
        }
    }

}
