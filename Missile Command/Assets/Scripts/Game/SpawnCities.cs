using UnityEngine;
using System.Collections;

public class SpawnCities : MonoBehaviour {
    public ArrayList cityAndLauncherPositions = new ArrayList();
    public GameObject City;
    public GameObject MissileSpawner;
    public GameObject Cursor;
    public float positionOffsetX = 10;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {            if (i == 0 || i == 4 || i == 8)
            {
                //Make Missile Spawners
                GameObject temp = Instantiate(MissileSpawner) as GameObject;
                temp.transform.localScale = new Vector3(1, 1, 1);
                temp.transform.Translate(i * positionOffsetX, 0, 0);
                //temp.transform.parent = transform;
                temp.SetActive(true);
                //temp.GetComponent<Renderer>().material.color = Random.ColorHSV();

                cityAndLauncherPositions.Add(temp.transform);

                if (temp.GetComponent<SpawnfriendlyMissile>() == null)
                {
                    temp.AddComponent<SpawnfriendlyMissile>();
                    temp.GetComponent<SpawnfriendlyMissile>().cursor = Cursor;
                }

            }
            else
            {
                //Make Cities
                GameObject temp = Instantiate(City) as GameObject;
                temp.transform.Translate(i * positionOffsetX, 0, 0);
                temp.transform.localScale = new Vector3(1, 1, 1);
                //temp.transform.parent = transform;
                temp.SetActive(true);
                //temp.GetComponent<Renderer>().material.color = Random.ColorHSV();

                cityAndLauncherPositions.Add(temp.transform);

                /*  if (temp.GetComponent<SpawnfriendlyMissile>() == null)
                  {
                      temp.AddComponent<SpawnfriendlyMissile>();

                  }*/



            }


        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
