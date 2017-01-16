using UnityEngine;
using System.Collections;

public class ExplodeOnGround : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Missile exploded on Ground!");

        if (other.gameObject.GetComponent<enemyMissileScript>() != null)
        {
            Debug.Log("Missile explodes on Ground");
            other.gameObject.GetComponent<enemyMissileScript>().Explode();
        }

        
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
