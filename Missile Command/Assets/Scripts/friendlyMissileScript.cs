using UnityEngine;
using System.Collections;

public class friendlyMissileScript : MonoBehaviour {
    public float speed=1;
    public GameObject cursor;
    private GameObject parent;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        direction = Vector3.Normalize(cursor.transform.localPosition);
    }
	
	// Update is called once per frame
	void Update () {
        
        
        gameObject.transform.Translate(direction*speed);
    }
}
