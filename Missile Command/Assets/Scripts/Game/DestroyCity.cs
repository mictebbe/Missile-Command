using UnityEngine;
using System.Collections;

public class DestroyCity : MonoBehaviour {

    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("City destroyed!");
       
        if (other.gameObject.GetComponent<enemyMissileScript>() != null)
        {
            other.gameObject.GetComponent<enemyMissileScript>().Explode();
        }

        Explode();
    }

    void Explode()
    {
        Destroy(gameObject);

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
