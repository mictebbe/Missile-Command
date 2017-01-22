using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ContinueAudio : MonoBehaviour {
    private AudioSource AudioSourceBGM;
    private AudioSource AudioSourceAtmo;

    // Declare properties
    public static ContinueAudio instance;
    // Creates an instance of gamestate as a gameobject if an instance does not exist
    // ---------------------------------------------------------------------------------------------------
    public static ContinueAudio Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ContinueAudio").AddComponent<ContinueAudio>();
                
            }
            return instance;
        }
    }

    //Awake is always called before any Start functions
    void Awake()
    {
        Debug.Log("Awake");
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        //startState();
    }
    // Use this for initialization
    void Start () {
        //gameObject.AddComponent<AudioSource>();
        //gameObject.AddComponent<AudioSource>();
        //gameObject.AddComponent<AudioListener>();
        //AudioSourceBGM = gameObject.GetComponent<AudioSource>();
        //AudioSourceAtmo= gameObject.GetComponent<AudioSource>()
        //AudioListener_ = gameObject.GetComponent<AudioListener>();
       
    
    }

     
             void OnEnable()
{
    //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
    SceneManager.sceneLoaded += OnLevelFinishedLoading;
}

void OnDisable()
{
    //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
    SceneManager.sceneLoaded -= OnLevelFinishedLoading;
}
    public AudioSource[] sounds;
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
{
        if (scene.name == "Level1")
        {
            sounds = gameObject.GetComponents<AudioSource>();
            sounds[0].Play();
        }
    Debug.Log("Level Loaded");
    Debug.Log(scene.name);
    Debug.Log(mode);
}


    
	
	
}
