using UnityEngine;
using System.Collections;

public class MouseControls : MonoBehaviour
{

	public GameObject cursor;
	public GameObject cursorPlane;

	Camera cam;

	void Start()
	{
		cam = GetComponent<Camera>();
	}

	void Update()
	{

		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		Plane p = new Plane(cursorPlane.transform.up, cursorPlane.transform.position);

		float distance;
		Vector3 pointOnPlane = new Vector3(0,0,0);
		if (p.Raycast(ray, out distance))
		{
			pointOnPlane = ray.GetPoint(distance);
		}
		cursor.transform.position = pointOnPlane;
	}
}
