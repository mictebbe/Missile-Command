using UnityEngine;
using System.Collections;

public class MouseControls : MonoBehaviour
{

	public GameObject cursor;
	public GameObject cursorPlane;

	public Texture2D cursorTexture;
	private float cursorSize = 40.0f;
	private GameObject missileLaunchers;


	Camera cam;

	void Start()
	{

		Cursor.visible = false;
		cam = GetComponent<Camera>();

		missileLaunchers = GameObject.Find("MissileLauncher");


	}

	void Update()
	{

		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		Plane p = new Plane(cursorPlane.transform.up, cursorPlane.transform.position);
       // cam.transform.forward=cursor.transform.position;

		float distance;
		Vector3 pointOnPlane = new Vector3(0, 0, 0);
		if (p.Raycast(ray, out distance))
		{
			pointOnPlane = ray.GetPoint(distance);
		}
		cursor.transform.position = pointOnPlane;

		for(var i = 0; i < missileLaunchers.transform.childCount; ++i)
		{
		
			var mL = missileLaunchers.transform.GetChild(i);
			var rumpf = mL.transform.GetChild(0).GetChild(0);
			var rohr = rumpf.GetChild(0);

			pointOnPlane.z -= 50;
			var direction = Vector3.Normalize(pointOnPlane - mL.transform.position);
			var rotation = Quaternion.LookRotation(direction);

			var eulerRotationX = rotation.eulerAngles;
			eulerRotationX.y =  180.0f - eulerRotationX.y;
			eulerRotationX.z = 0;

			var eulerRotationY = rotation.eulerAngles;
			eulerRotationY.y *= -1;
			eulerRotationY.x = 0;
			eulerRotationY.z = 0;

			rumpf.transform.rotation = Quaternion.Euler(eulerRotationY);
			rohr.transform.rotation = Quaternion.Euler(eulerRotationX);
		}


	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Event.current.mousePosition.x - (cursorSize / 2), Event.current.mousePosition.y - (cursorSize / 2), cursorSize, cursorSize), cursorTexture);
	}
}
