using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackgroundMusic : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip levelBackgroundMusic;
    public AudioClip menuBackgroundMusic;
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
                instance = new GameObject("BackgroundMusic").AddComponent<BackgroundMusic>();
                
            }
            return instance;
        }
    }

    //Awake is always called before any Start functions
    void Awake()
    {

      

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
        DontDestroyOnLoad(gameObject);
        //gameObject.AddComponent<AudioSource>();
        
       
       
        audioSource.playOnAwake = true;
        audioSource.clip = menuBackgroundMusic;
        audioSource.loop = true;
        audioSource.volume = 1f;

        //AudioSourceAtmo = sounds[1];
        //AudioSourceAtmo.playOnAwake = false;
        //AudioSourceAtmo.loop = true;
        //AudioSourceAtmo.volume = 0.5f;

        StartCoroutine(FadeIn());
        Debug.Log(audioSource.clip.name);
        Debug.Log(menuBackgroundMusic.name);
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
   
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
{
        audioSource = gameObject.GetComponent<AudioSource>();
        if (scene.name == "Level1")
        {

            //AudioSourceAtmo.Play();
            if (audioSource.clip.name != levelBackgroundMusic.name)
            {
                audioSource.clip = levelBackgroundMusic;
            }
        }
        else
        {
          //  if (audioSource.clip.name != menuBackgroundMusic.name)
            {
                Debug.Log(menuBackgroundMusic.name);
             audioSource.clip = menuBackgroundMusic;
            }
            StartCoroutine(FadeIn());

        }

     


    Debug.Log("Level Loaded");
    Debug.Log(scene.name);
    Debug.Log(mode);
}

    IEnumerator FadeIn()
    {
        for (float i = 0; i <= 1; i += 0.01f)
        {
            audioSource.volume = i;
            yield return null;
        }
    }



}
