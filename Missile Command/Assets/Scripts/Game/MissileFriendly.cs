using UnityEngine;
using System.Collections;

public class MissileFriendly : MonoBehaviour
{
	public GameObject missilePrefab;
	public GameObject explosionPrefab;
	public Vector3 targetPosition;
    public AudioClip flySound;
	public float noiseAmp = 0;
	public float noiseScale = 0;

	public float speed = 1.0f;

	private Vector3 direction;
	private GameObject explosion;
	private bool once = true;
	private bool moving = true;

	public ParticleSystem smoke;

	void Start()
	{
        explosion = Instantiate(explosionPrefab) as GameObject;
		explosion.transform.parent = gameObject.transform;
		explosion.transform.localPosition = new Vector3(0, 0, 0);
		explosion.SetActive(false);

		smoke = GetComponentInChildren<ParticleSystem>();
	}

	void Update()
	{
		if (moving)
		{
			StartCoroutine(Fly());
		}
		if (smoke)
		{
			if (!smoke.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}

	IEnumerator Fly()
	{
		var position = gameObject.transform.position;
        //if (Vector3.Distance(position, targetPosition) > 3.0f)
        if(Vector3.Distance(position, targetPosition) > 10)
        {
			var path = targetPosition - position;
			direction = Vector3.Normalize(path);

			var noise = noiseAmp * (Mathf.PerlinNoise(path.x * noiseScale, path.y * noiseScale) - 0.5f);
			var side = new Vector3(0, 0, 1);
			var modDirection = Vector3.Cross(direction, side)*noise;

			var translation = (direction * speed*Time.deltaTime) + (modDirection * noise);
            
            gameObject.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(-translation);
            gameObject.transform.position = Vector3.MoveTowards(position+(modDirection * noise), targetPosition, speed * Time.deltaTime);
            //gameObject.transform.Translate(translation);
        }
		else //if(once)
		{
			once = false;
			moving = false;
            Destroy(transform.GetChild(0).gameObject);
            Explode();
		}
		yield return null;
	}

	void Explode()
	{
		explosion.SetActive(true);
       

        //transform.GetChild(0).gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.name == "MissileEnemy(Clone)")
		{
			
			GameManager.instance.addToScore(ScoreState.missileDestroyed);
			Explode();
		}
	}
}
