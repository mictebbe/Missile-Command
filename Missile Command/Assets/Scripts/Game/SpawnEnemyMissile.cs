using UnityEngine;
using System.Collections;

public class SpawnEnemyMissile : MonoBehaviour {
    public GameObject mainGame;
    public GameObject enemyMissilePrefab;
    public int amount;
    public float speed;
    public GameObject enemyMissileExplosion;
    public GameObject target;
    private ArrayList missiles = new ArrayList();    private int currentAmount = 0;

    // Use this for initialization
    void Start()
    {


        mainGame = GameObject.Find("MainGameScript");
        
        this.speed = GameManager.Instance.getLevel()*0.6f;
        for (int i = 0; i <= amount; i++)
        {            GameObject temp = Instantiate(enemyMissilePrefab) as GameObject;            //temp.transform.localScale = new Vector3(1, 1, 1);            //temp.transform.parent = transform;            temp.SetActive(false);            

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
        if (target == null){
            gameObject.GetComponent<ChangeEnemyTargetAndPosition>().changeTarget();

        }

        //TODO Spawn Missiles differently
        if (Time.frameCount%60==0 && !GameManager.Instance.isDestroyed())
        {
            if (currentAmount > 0)
            {
                GameObject current = (GameObject)missiles[currentAmount - 1];
                current.GetComponent<enemyMissileScript>().enemyExplosionPrefab = enemyMissileExplosion;
                if (target != null)
                {
                    current.GetComponent<enemyMissileScript>().target = target;
                }
                else
                {
                    gameObject.GetComponent<ChangeEnemyTargetAndPosition>().changeTarget();
                   
                }
                
                current.GetComponent<enemyMissileScript>().speed= speed;
                current.SetActive(true);
                current.transform.Translate(gameObject.transform.localPosition);
                currentAmount-=1;
             

            }
            else
            {
                Debug.Log("No missiles left in Missile Launcher '" + gameObject.name + "'");
            }
        }
    }
}
