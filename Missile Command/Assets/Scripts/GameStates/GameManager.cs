using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    // Declare properties
    public static GameManager instance;
    public LevelGenerator levelGenerator;

    // Declare properties
    private int activeLevel;         // Active level
   
    private int score;                  // Score
    private bool City1Destroyed;                  // is city 1 destroyed?
    private bool City2Destroyed;                  // is city 2 destroyed?
    private bool City3Destroyed;                  // is city 3 destroyed?
    private bool City4Destroyed;                  // is city 4 destroyed?
    private bool City5Destroyed;                  // is city 5 destroyed?
    private bool City6Destroyed;                  // is city 6 destroyed?
    

    // Creates an instance of gamestate as a gameobject if an instance does not exist
    // ---------------------------------------------------------------------------------------------------
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }

            return instance;
        }
    }


    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
      /*  if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);*/

        //Get a component reference to the attached BoardManager script
        levelGenerator = new GameObject("levelGenerator").AddComponent<LevelGenerator>(); ;

        //Call the InitGame function to initialize the first level 
        startState();
    }

    //Initializes the game for each level.
    void initLevel()
    {
        
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        levelGenerator.generateLevel(this.activeLevel);

    }


    

    // Sets the instance to null when the application quits
    public void OnApplicationQuit()
    {
        instance = null;
    }
    // ---------------------------------------------------------------------------------------------------


    // ---------------------------------------------------------------------------------------------------
    // startState()
    // --------------------------------------------------------------------------------------------------- 
    // Creates a new game state
    // ---------------------------------------------------------------------------------------------------
    public void startState()
    {
        print("Creating a new game state");

         activeLevel=1;         // Active level
    
    score=0;                  // Score
    
    City1Destroyed=false;                  // is city 1 destroyd?
    City2Destroyed = false;                  // is city 2 destroyd?
    City3Destroyed = false;                  // is city 3 destroyd?
    City4Destroyed = false;                  // is city 4 destroyd?
    City5Destroyed = false;                  // is city 5 destroyd?
    City6Destroyed = false;                  // is city 6 destroyd?

        initLevel();
}

    public int getLevel()
    {

        return this.activeLevel;
    }

    public void addLevel()
    {

        this.activeLevel++;

    }
}
