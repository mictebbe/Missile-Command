using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {

	public GameObject explosionPrefab;
    
    void Start () {

        if (GameManager.Instance.isCityDestroyed(this.gameObject)) {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

		explosionPrefab = Instantiate(explosionPrefab) as GameObject;
		explosionPrefab.transform.parent = gameObject.transform;
		explosionPrefab.transform.localPosition = new Vector3(0, 0, 0);
		explosionPrefab.SetActive(false);
	}
	
	void Update () {
		// ...
	}

	void Explode()
	{
		GameManager.Instance.destroyCity(gameObject);

		if (GameManager.Instance.isDestroyed())
		{
			GameManager.Instance.endGame();
		}
		
		// Change model to destroyed building
		gameObject.transform.GetChild(0).gameObject.SetActive(false);
		gameObject.transform.GetChild(1).gameObject.SetActive(true);

		explosionPrefab.SetActive(true);
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "MissileEnemy(Clone)" )
		{
			Explode();
		}
	}
}
