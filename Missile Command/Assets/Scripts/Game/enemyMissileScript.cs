using UnityEngine;
using System.Collections;

public class enemyMissileScript : MonoBehaviour {
    public float speed = 1;
    public GameObject enemyExplosionPrefab;
    private Vector3 direction;
    private Vector3 explosionPosition;
    private GameObject enemyExplosion;
    public GameObject target;
    bool notExploded = true;
    // Use this for initialization
    void Start()
    {
        if (explosionPosition != null)
        {
            explosionPosition = target.transform.position;

        }
        
        direction = Vector3.Normalize(explosionPosition - gameObject.transform.localPosition);
       // Debug.Log("Enemy Explosion position: " + explosionPosition);
       // Debug.Log("Enemy Direction: " + direction);

        enemyExplosion = Instantiate(enemyExplosionPrefab) as GameObject;
        
        enemyExplosion.transform.localPosition = gameObject.transform.localPosition;
        enemyExplosion.SetActive(false);

        if (enemyExplosion.GetComponent<ExplosionScript>() == null)
        {
            enemyExplosion.AddComponent<ExplosionScript>();
        }

        if (enemyExplosion.GetComponent<ExplosionCollision>() == null)
        {
            enemyExplosion.AddComponent<ExplosionCollision>();
        }

    }

   public void Explode()
    {
        if (notExploded)
        {
            // Debug.Log("Enemy Missile explodes at: "+ gameObject.transform.localPosition);

            enemyExplosion.SetActive(true);
            GameManager.Instance.enemyMissilesLiving -= 1;

            //Debug.Log("Missiles Living: " + GameManager.Instance.enemyMissilesLiving);
            Destroy(gameObject);
            notExploded = false;
        }
    }

 
    // Update is called once per frame
    void Update()
    {


        //gameObject.transform.Translate(direction * speed);
        //if (enemyExplosion.GetComponent<ParticleSystem>.isActiveAndEnabled()!=true)
        if (enemyExplosion != null) {
            enemyExplosion.transform.Translate(direction * speed);
        }
            
        
        if (gameObject.GetComponent<Rigidbody>() != null)
        {
            StartCoroutine(Fly());
           
        }
        /* if (Vector3.Magnitude(gameObject.GetComponent<Rigidbody>().transform.localPosition - explosionPosition) <= 1 * speed)
         {

             Explode();
         }*/
    }

    IEnumerator Fly()
    {
        gameObject.GetComponent<Rigidbody>().transform.Translate(direction * speed);
        
        yield return null;
    }
}
