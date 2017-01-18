using UnityEngine;
using System.Collections;

public class ChangeEnemyTargetAndPosition : MonoBehaviour {
    public GameObject City1;
    public GameObject City2;
    public GameObject City3;
    public GameObject City4;
    public GameObject City5;
    public GameObject City6;
    public GameObject MissileSpawnerLeft;
    public GameObject MissileSpawnerCenter;
    public GameObject MissileSpawnerRight;
    private ArrayList Targets = new ArrayList();


    public void changeTarget(GameObject newTarget)
    {
        if (gameObject.GetComponent<SpawnEnemyMissile>() != null)
        {
            gameObject.GetComponent<SpawnEnemyMissile>().target = newTarget;

        }
    }

    public void changeTarget()
    {
        GameObject newTarget;

        newTarget = (GameObject)Targets[(int)Mathf.Floor(Random.Range(0,Targets.Count))];

        
        if (gameObject.GetComponent<SpawnEnemyMissile>() != null && newTarget!=null)
        {
            gameObject.GetComponent<SpawnEnemyMissile>().target = newTarget;
           // Debug.Log("AutoChange Target to '" + newTarget + "'");

        }
    }

    public void removeTarget(GameObject target)
    {
       if( Targets.Contains(target)){
            Targets.Remove(target);

        }

    }
    // Use this for initialization
    void Start () {
        Targets.Add(City1);
        Targets.Add(City2);
        Targets.Add(City3);
        Targets.Add(City4);
        Targets.Add(City5);
        Targets.Add(City6);
        Targets.Add(MissileSpawnerLeft);
        Targets.Add(MissileSpawnerCenter);
        Targets.Add(MissileSpawnerRight);

    }

    
	
	// Update is called once per frame
	void Update () {

            changeTarget();   
	}
}
