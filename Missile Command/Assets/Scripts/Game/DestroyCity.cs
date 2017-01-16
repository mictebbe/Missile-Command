using UnityEngine;
using System.Collections;

public class DestroyCity : MonoBehaviour {
    public string cityName;
    
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
            GameManager.Instance.endGame();

        }
        //Debug.Log("City destroyed! "+ gameObject.name);

				gameObject.transform.GetChild(0).gameObject.SetActive(false);
				gameObject.transform.GetChild(1).gameObject.SetActive(true);



	}
    // Use this for initialization
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
