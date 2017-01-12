using UnityEngine;
using System.Collections;

public class DestroyCity : MonoBehaviour {

    
    void OnTriggerEnter(Collider other)
    {
       
       
        if (other.gameObject.GetComponent<enemyMissileScript>() != null)
        {
            other.gameObject.GetComponent<enemyMissileScript>().Explode();
        }

        Explode();
    }

    void Explode()
    {
        GameManager.Instance.destroyCity(gameObject);
        if (GameManager.Instance.isDestroyed())
        {
            LevelGenerator.Instance.showEndScreen();

        }
        //Debug.Log("City destroyed! "+ gameObject.name);

				gameObject.transform.GetChild(0).gameObject.SetActive(false);
				gameObject.transform.GetChild(1).gameObject.SetActive(true);



	}
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
