using UnityEngine;
using System.Collections;

public class ExplosionCollision : MonoBehaviour {
    public float maxExplosionCollision=30;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Missile explodes from Explosion.");

        if (other.gameObject.GetComponent<enemyMissileScript>() != null)
        {
            other.gameObject.GetComponent<enemyMissileScript>().Explode();
        }

       
    }
    // Use this for initialization
    void Start () {
        
        //gameObject.GetComponent<MeshCollider>().GetComponent<Mesh>().bounds.Expand(1);
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<SphereCollider>().radius += 0.5f;
        if ( gameObject.GetComponent<SphereCollider>() != null)
          {

            

            if (gameObject.GetComponent<SphereCollider>().radius >= maxExplosionCollision)
              {
                Destroy(gameObject);
              }
              else
              {
                gameObject.GetComponent<SphereCollider>().radius += 0.05f;

            }
          }
          

    }
}
