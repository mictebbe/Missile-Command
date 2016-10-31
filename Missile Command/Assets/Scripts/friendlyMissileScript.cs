using UnityEngine;
using System.Collections;

public class friendlyMissileScript : MonoBehaviour {
    public float speed=1;
    public GameObject cursor;
    public GameObject friendlyExplosionPrefab;
    private GameObject parent;
    private Vector3 direction;
    private Vector3 explosionPosition;
    private GameObject friendlyExplosion;
    // Use this for initialization
    void Start () {
        explosionPosition = cursor.transform.localPosition;
        direction = Vector3.Normalize(explosionPosition);
        Debug.Log("Explosion position: "+explosionPosition);
        Debug.Log("Direction: " + direction);

        friendlyExplosion = Instantiate(friendlyExplosionPrefab) as GameObject;
        //friendlyExplosion.transform.localScale = new Vector3(1, 1, 1);
        friendlyExplosion.transform.localPosition = explosionPosition;
        friendlyExplosion.SetActive(false);

        if (friendlyExplosion.GetComponent<ExplosionScript>() == null)
        {
            friendlyExplosion.AddComponent<ExplosionScript>();
        }

    }
	
	// Update is called once per frame
	void Update () {
        
        
        gameObject.transform.Translate(direction*speed);
        if (Vector3.Magnitude(gameObject.transform.localPosition-explosionPosition)<=1*speed)
        {
            Object.Destroy(gameObject);
            Debug.Log("Friendly Missile explodes.");
            friendlyExplosion.SetActive(true);
            //(ParticleSystem)friendlyExplosion.Play();

        }
    }
}
