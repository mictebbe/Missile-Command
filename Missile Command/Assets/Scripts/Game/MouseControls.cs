using UnityEngine;
using System.Collections;

public class MouseControls : MonoBehaviour
{

	public GameObject cursor;
	public GameObject cursorPlane;

	public Texture2D cursorTexture;
	private float cursorSize = 40.0f;


	Camera cam;

	void Start()
	{

		Cursor.visible = false;
		cam = GetComponent<Camera>();

	}

	void Update()
	{

		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		Plane p = new Plane(cursorPlane.transform.up, cursorPlane.transform.position);

		float distance;
		Vector3 pointOnPlane = new Vector3(0, 0, 0);
		if (p.Raycast(ray, out distance))
		{
			pointOnPlane = ray.GetPoint(distance);
		}
		cursor.transform.position = pointOnPlane;


	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Event.current.mousePosition.x - (cursorSize / 2), Event.current.mousePosition.y - (cursorSize / 2), cursorSize, cursorSize), cursorTexture);
	}
}
