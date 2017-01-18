using UnityEngine;
using System.Collections;
using System;


public class GameManager : MonoBehaviour
{
	// Declare properties
	public static GameManager instance;
	
	// Declare properties
	private int activeLevel; 
	private int score = 0;
	private int lastLevelScore = 0;
	private int enemyMissileAmount = 2;
	
	//friendlyMissileAmount is the initial amount of shots the player has per launcher.
	private int friendlyMissileAmount = 10;

	private bool CityDestroyed1;                  // is city 1 destroyed?
	private bool CityDestroyed2;                  // is city 2 destroyed?
	private bool CityDestroyed3;                  // is city 3 destroyed?
	private bool CityDestroyed4;                  // is city 4 destroyed?
	private bool CityDestroyed5;                  // is city 5 destroyed?
	private bool CityDestroyed6;                  // is city 6 destroyed?

	public int enemyMissilesLiving;
	
	//friendlyMissilesLiving is the sum of shots the player has left from all launchers.
	public int friendlyMissilesLiving;

	private bool gameEnded = false;


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

	public int getEnemyMissileAmount()
	{
		return enemyMissileAmount;
	}

	public int getFriendlyMissileAmount()
	{
		return friendlyMissileAmount;
	}
	//Initializes the game for each level.
	public void initLevel()
	{
		//Call the SetupScene function of the BoardManager script, pass it current level number.
		LevelGenerator.Instance.generateLevel();
	}

	private void resetMissiles()
	{
		enemyMissilesLiving = enemyMissileAmount;
		friendlyMissilesLiving = 3 * friendlyMissileAmount;
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
	public void startNewGame()
	{
		gameEnded = false;
		
		resetMissiles();

		activeLevel = 1;                
		score = 0;

		// is city destroyd?
		CityDestroyed1 = false;                
		CityDestroyed2 = false;                  
		CityDestroyed3 = false;                  
		CityDestroyed4 = false;                  
		CityDestroyed5 = false;                  
		CityDestroyed6 = false;                  	  
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

	public bool isDestroyed()
	{
		return (CityDestroyed1 && CityDestroyed2 && CityDestroyed3 && CityDestroyed4 && CityDestroyed5 && CityDestroyed6);
	}

	public void destroyCity(GameObject cityToDestroy)
	{

		//Debug.Log("DESTROYCITY " + cityToDestroy.name);
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

	public bool isCityDestroyed(GameObject cityToDestroy)
	{
		switch (cityToDestroy.name)
		{
			case "City1":
				return this.CityDestroyed1;

			case "City2":
				return this.CityDestroyed2;

			case "City3":
				return this.CityDestroyed3;

			case "City4":
				return this.CityDestroyed4;

			case "City5":
				return this.CityDestroyed5;

			case "City6":
				return this.CityDestroyed6;

			default:
				return true;
		}
	}

	public void goToMenu()
	{
		LevelGenerator.Instance.showStartScreen();
	}

	public void addToScore(String eventType)
	{
		switch (eventType)
		{
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

	public void goToOptions()
	{
		LevelGenerator.Instance.showOptions();
	}

	void goToNextLevel()
	{
		countLevelScore();

		activeLevel += 1;

		for (int i = 0; i < (score - lastLevelScore) / 10000; i++)
		{
			reviveCity();
		}
		lastLevelScore = score;
		resetMissiles();
		initLevel();
	}

	void countLevelScore()
	{
		//Count City Scores
		if (!CityDestroyed1)
		{
			addToScore("City left");
		}

		if (!CityDestroyed2)
		{
			addToScore("City left");
		}
		if (!CityDestroyed3)
		{
			addToScore("City left");
		}
		if (!CityDestroyed4)
		{
			addToScore("City left");
		}
		if (!CityDestroyed5)
		{
			addToScore("City left");
		}
		if (!CityDestroyed6)
		{
			addToScore("City left");
		}

		//Count Friendly missile Scores
		for (int i = 0; i < friendlyMissilesLiving; i++)
		{
			addToScore("Friendly Missile left");
		}

	}

	void Update()
	{
		if (isDestroyed())
		{
			endGame();
		}
		if (enemyMissilesLiving == 0)
		{
			goToNextLevel();
		}
	}

	void reviveCity()
	{
		//Make Array of Cities
		ArrayList destroyedCities = new ArrayList();
		if (CityDestroyed1)
		{
			destroyedCities.Add(CityDestroyed1);
		}
		if (CityDestroyed2)
		{
			destroyedCities.Add(CityDestroyed2);
		}
		if (CityDestroyed3)
		{
			destroyedCities.Add(CityDestroyed3);
		}
		if (CityDestroyed4)
		{
			destroyedCities.Add(CityDestroyed4);
		}
		if (CityDestroyed5)
		{
			destroyedCities.Add(CityDestroyed5);
		}
		if (CityDestroyed6)
		{
			destroyedCities.Add(CityDestroyed6);
		}

		//Pick random City
		object cityToRevive = destroyedCities[UnityEngine.Random.Range(0, destroyedCities.Count)];

		//Revive picked city
		if (cityToRevive.Equals(CityDestroyed1))
		{
			CityDestroyed1 = false;
		}

		if (cityToRevive.Equals(CityDestroyed2))
		{
			CityDestroyed2 = false;
		}
		if (cityToRevive.Equals(CityDestroyed3))
		{
			CityDestroyed3 = false;
		}
		if (cityToRevive.Equals(CityDestroyed4))
		{
			CityDestroyed4 = false;
		}
		if (cityToRevive.Equals(CityDestroyed5))
		{
			CityDestroyed5 = false;
		}
		if (cityToRevive.Equals(CityDestroyed6))
		{
			CityDestroyed6 = false;
		}
	}

	public void endGame()
	{
		if (!gameEnded)
		{
			gameEnded = true;
			LevelGenerator.Instance.showEndScreen();
		}
	}

	public float getEnemyMissileSpeed()
	{
		return 1.5f + 0.05f * activeLevel;
	}
}