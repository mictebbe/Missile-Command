using UnityEngine;
using System.Collections;

public class SpawnfriendlyMissile : MonoBehaviour {
    public GameObject missilePrefab;
    public int amount;

    private ArrayList missiles = new ArrayList();    private int currentAmount = 0;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {            GameObject temp = Instantiate(missilePrefab) as GameObject;            temp.transform.localScale = new Vector3(1, 1, 1);            temp.transform.parent = transform;            temp.SetActive(false);            //temp.GetComponent<Renderer>().material.color = Random.ColorHSV();

            missiles.Add(temp);

            if (temp.GetComponent<friendlyMissileScript>() == null)
            {
                temp.AddComponent<friendlyMissileScript>();            }

            currentAmount++;
        }
    }
	
	// Update is called once per frame
	void Update () {


            if (Time.frameCount % 30 == 0 && currentAmount > 0)
            {
                GameObject current = (GameObject)missiles[currentAmount-1];

                current.SetActive(true);

                currentAmount--;

            }
        }
}
