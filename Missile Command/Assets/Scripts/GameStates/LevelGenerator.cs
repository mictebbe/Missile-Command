using UnityEngine;
using UnityEngine.SceneManagement;
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

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);



        //Call the InitGame function to initialize the first level 
        //startState();
    }



    public void generateLevel()
    {
        
        SceneManager.LoadScene("Level1");
       

    }

    public void showEndScreen()
    {
        SceneManager.LoadScene("EndScreen");

    }

    public void showStartScreen()
    {
        SceneManager.LoadScene("StartScreen");

    }

    public void showOptions()
    {
        //SceneManager.LoadScene("Options");
        //TODO: Show options overlay
        Debug.Log("not implemented yet.");
    }
}
