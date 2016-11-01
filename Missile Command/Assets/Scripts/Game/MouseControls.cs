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
        //Vector2 mousePosition = Input.mousePosition;
        //Ray ray = cam.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, 100));
        
        cursor.transform.Translate(new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0));
    }
}
