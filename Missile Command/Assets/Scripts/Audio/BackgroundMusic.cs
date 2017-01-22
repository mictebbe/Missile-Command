using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackgroundMusic : MonoBehaviour {
    private AudioSource AudioSource;
    private AudioClip levelBackgroundMusic;
    private AudioClip menuBackgroundMusic;
    private Object[] clips;


    // Declare properties
    public static BackgroundMusic instance;
    // Creates an instance of gamestate as a gameobject if an instance does not exist
    // ---------------------------------------------------------------------------------------------------
    public static BackgroundMusic Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ContinueAudio").AddComponent<BackgroundMusic>();
                
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
        
    }
    // Use this for initialization
    void Start () {
        gameObject.AddComponent<AudioSource>();
        
        AudioSource[] sounds = gameObject.GetComponents<AudioSource>(); ;
        clips = Resources.LoadAll("Sounds/BackgroundMusic");
        foreach (Object current in clips)
        {
            Debug.Log("clips"+current.name);

        }
        foreach (AudioSource current in sounds)
        {
            Debug.Log("AudioSoures"+current.name);

        }
        AudioSource= sounds[0];
        AudioSource.playOnAwake = true;
        AudioSource.loop = true;
        AudioSource.volume = 0.5f;

        //AudioSourceAtmo = sounds[1];
        //AudioSourceAtmo.playOnAwake = false;
        //AudioSourceAtmo.loop = true;
        //AudioSourceAtmo.volume = 0.5f;


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

            //AudioSourceAtmo.Play();
            if (AudioSource.clip.name != levelBackgroundMusic.name)
            {
                AudioSource.clip = levelBackgroundMusic;
            }
        }
        else
        {
            if (AudioSource.clip.name != menuBackgroundMusic.name)
            {
                AudioSource.clip = menuBackgroundMusic;
            }


        }




    Debug.Log("Level Loaded");
    Debug.Log(scene.name);
    Debug.Log(mode);
}


    
	
}
