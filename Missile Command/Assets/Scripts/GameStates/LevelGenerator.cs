using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
    public static LevelGenerator instance;

    public static LevelGenerator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("levelGenerator").AddComponent<LevelGenerator>();
            }

            return instance;
        }
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void generateLevel(int lvl)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");


    }
}
