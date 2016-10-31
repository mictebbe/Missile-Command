using UnityEngine;
using System.Collections;

public class friendlyMissileScript : MonoBehaviour {
    public float speed=1;
    private GameObject parent;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        parent = gameObject.transform.parent.gameObject;
        direction = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f))*speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (parent)
        {
            //gameObject.transform.RotateAround(parent.transform.position, up, speed * Time.deltaTime);
        }
        
        gameObject.transform.Translate(direction);
    }
}
