using UnityEngine;
using System.Collections;

public class SpawnEnemyMissile : MonoBehaviour {
    public GameObject enemyMissilePrefab;
    public int amount;
    public GameObject enemyMissileExplosion;
    private ArrayList missiles = new ArrayList();    private int currentAmount = 0;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {            GameObject temp = Instantiate(enemyMissilePrefab) as GameObject;            //temp.transform.localScale = new Vector3(1, 1, 1);            //temp.transform.parent = transform;            temp.SetActive(false);            //temp.GetComponent<Renderer>().material.color = Random.ColorHSV();

            missiles.Add(temp);

            if (temp.GetComponent<enemyMissileScript>() == null)
            {
                temp.AddComponent<enemyMissileScript>();            }



            currentAmount++;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //TODO Spawn Missiles differently
        if (Time.frameCount%100==0)
        {
            if (currentAmount > 0)
            {
                GameObject current = (GameObject)missiles[currentAmount - 1];
                current.GetComponent<enemyMissileScript>().enemyExplosionPrefab = enemyMissileExplosion;
                current.SetActive(true);

                currentAmount--;
            }
            else
            {
                Debug.Log("No missiles left in Missile Launcher '" + gameObject.name + "'");
            }
        }
    }
}
