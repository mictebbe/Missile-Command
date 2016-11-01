using UnityEngine;
using System.Collections;

public class DestroyMissileSpawner : MonoBehaviour {



    void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.GetComponent<enemyMissileScript>() != null)
        {
            other.gameObject.GetComponent<enemyMissileScript>().Explode();
            Debug.Log("Missile Launcher destroyed!");
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
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
