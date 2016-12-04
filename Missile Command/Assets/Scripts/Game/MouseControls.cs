using UnityEngine;
using System.Collections;

public class MouseControls : MonoBehaviour {

    Camera cam;
    public GameObject cursor;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
				Vector3 cfPosition = GameObject.Find("Collisionfloor").transform.position;
				Ray ray = cam.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, cfPosition.z));
				
				float camCFDistance = Vector3.Distance(cfPosition, cam.transform.position);
				Vector3 p = ray.GetPoint(camCFDistance);

				cursor.transform.position = p;
				//cursor.transform.Translate(new Vector3(Input.GetAxis("Mouse X")*10, Input.GetAxis("Mouse Y")*10, 0));
	}
}
