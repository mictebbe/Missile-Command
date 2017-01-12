using UnityEngine;
using System.Collections;

public class ExplosionCollision : MonoBehaviour {
    public float maxExplosionCollision=30;
    public float grothAndShrinkRate = 1;
    
    private bool growing = true;

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Missile explodes from Explosion.");
       
        if (other.gameObject.GetComponent<enemyMissileScript>() != null)
        {
            other.gameObject.GetComponent<enemyMissileScript>().Explode();
            GameManager.Instance.addToScore("Enemy Missile destroyed");
        }

        if (other.gameObject.GetComponent<Helicopter>() != null)
        {
            other.gameObject.GetComponent<Helicopter>().Explode();
            GameManager.Instance.addToScore("Helicopter destroyed");

        }


       
    }
    // Use this for initialization
    void Start () {
        gameObject.AddComponent<CapsuleCollider>();
        gameObject.GetComponent<CapsuleCollider>().radius = 10;
        gameObject.GetComponent<CapsuleCollider>().direction =0 ;
        gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        gameObject.GetComponent<CapsuleCollider>().height = 1000;


    }
	
	// Update is called once per frame
    //TODO: Coroutine
	void Update () {



       // gameObject.GetComponent<SphereCollider>().radius += 2f;
        if ( gameObject.GetComponent<CapsuleCollider>() != null)
          {

            

      
            if (growing)
            {
                gameObject.GetComponent<CapsuleCollider>().radius += grothAndShrinkRate;
              //  Debug.Log("growing"+ gameObject.GetComponent<SphereCollider>().radius);

            }else{
                gameObject.GetComponent<CapsuleCollider>().radius -= grothAndShrinkRate;
              //  Debug.Log("shrinking "+ gameObject.GetComponent<SphereCollider>().radius);
            }

            if (gameObject.GetComponent<CapsuleCollider>().radius >= maxExplosionCollision)
            {
                growing = false;
               // Debug.Log("growing is false");
            }

            if (gameObject.GetComponent<CapsuleCollider>().radius <= 0)
            {
               // Debug.Log("dead" + gameObject.GetComponent<SphereCollider>().radius);
                Destroy(gameObject);
                
            }

          }
          

    }
}
