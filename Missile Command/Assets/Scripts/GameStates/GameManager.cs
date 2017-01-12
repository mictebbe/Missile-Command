using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

    // Declare properties
    public static GameManager instance;

  

    // Declare properties
    private int activeLevel;         // Active level
    private int score=0;                  // Score
    private bool CityDestroyed1;                  // is city 1 destroyed?
    private bool CityDestroyed2;                  // is city 2 destroyed?
    private bool CityDestroyed3;                  // is city 3 destroyed?
    private bool CityDestroyed4;                  // is city 4 destroyed?
    private bool CityDestroyed5;                  // is city 5 destroyed?
    private bool CityDestroyed6;                  // is city 6 destroyed?

    public int EnemyMissilesLiving;



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

    //Initializes the game for each level.
    public void initLevel()
    {

        //Call the SetupScene function of the BoardManager script, pass it current level number.
        LevelGenerator.Instance.generateLevel(this.activeLevel);

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

        CityDestroyed1 = false;                  // is city 1 destroyd?
        CityDestroyed2 = false;                  // is city 2 destroyd?
        CityDestroyed3 = false;                  // is city 3 destroyd?
        CityDestroyed4 = false;                  // is city 4 destroyd?
        CityDestroyed5 = false;                  // is city 5 destroyd?
        CityDestroyed6 = false;                  // is city 6 destroyd?

       
}

    public int getLevel()
    {

        return this.activeLevel;
    }

    public void addLevel()
    {

        this.activeLevel++;

    }


    public bool isDestroyed()
    {

        return (CityDestroyed1 && CityDestroyed2 && CityDestroyed3 && CityDestroyed4 && CityDestroyed5 && CityDestroyed6 );
    }

    public void destroyCity(GameObject cityToDestroy)
    {

        Debug.Log("DESTROYCITY " + cityToDestroy.name);
        switch (cityToDestroy.name)
        {
            case "City1":
                this.CityDestroyed1 = true;

                break;

            case "City2":
                this.CityDestroyed2 = true;

                break;

            case "City3":
                this.CityDestroyed3 = true;

                break;

            case "City4":
                this.CityDestroyed4 = true;

                break;

            case "City5":
                this.CityDestroyed5 = true;

                break;

            case "City6":
                this.CityDestroyed6 = true;

                break;


        }

    }

   public void goToMenu()
    {
        LevelGenerator.Instance.showStartScreen();


    }


    public void addToScore(String eventType)
    {

        switch(eventType){
            case "Enemy Missile destroyed":
                this.score += 25;
                
                break;
            case "Helicopter destroyed":
                this.score += 50;

                break;
            case "Friendly Missile left":
                this.score += 10;
               
                break;
            case "City left":
                this.score += 100;
                
                break;
              


        }
       

    }

    

    public int getScore()
    {

        return score;
    }
}
