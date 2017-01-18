using UnityEngine;
using System.Collections;

public class DestroyMissileSpawner : MonoBehaviour {



    void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.GetComponent<enemyMissileScript>() != null)
        {
            //Debug.Log("Missile explodes on Spawner");
            other.gameObject.GetComponent<enemyMissileScript>().Explode();
            //Debug.Log("Missile Launcher destroyed!");
        }

        Explode();
    }

    void Explode()
    {
        if (GameObject.Find("Enemy Missile Spawner")!=null)
        {
            GameObject.Find("Enemy Missile Spawner").GetComponent<ChangeEnemyTargetAndPosition>().removeTarget(gameObject);
        }
        Destroy(gameObject);

        Destroy(gameObject.transform.GetChild(0).gameObject);


    }
   

  
}
