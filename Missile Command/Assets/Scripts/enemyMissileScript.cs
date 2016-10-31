using UnityEngine;
using System.Collections;

public class enemyMissileScript : MonoBehaviour {
    public float speed = 1;
    public GameObject enemyExplosionPrefab;
    private Vector3 direction;
    private Vector3 explosionPosition;
    private GameObject enemyExplosion;
    // Use this for initialization
    void Start()
    {
        explosionPosition= new Vector3(0,-15,0) ;
        direction = Vector3.Normalize(explosionPosition);
        Debug.Log("Enemy Explosion position: " + explosionPosition);
        Debug.Log("Enemy Direction: " + direction);

        enemyExplosion = Instantiate(enemyExplosionPrefab) as GameObject;
        //enemyExplosion.transform.localScale = new Vector3(1, 1, 1);
        enemyExplosion.transform.localPosition = explosionPosition;
        enemyExplosion.SetActive(false);

        if (enemyExplosion.GetComponent<ExplosionScript>() == null)
        {
            enemyExplosion.AddComponent<ExplosionScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {


        gameObject.transform.Translate(direction * speed);
        if (Vector3.Magnitude(gameObject.transform.localPosition - explosionPosition) <= 1 * speed)
        {
            Object.Destroy(gameObject);
            Debug.Log("Enemy Missile explodes.");
            enemyExplosion.SetActive(true);
            //(ParticleSystem)friendlyExplosion.Play();

        }
    }
}
