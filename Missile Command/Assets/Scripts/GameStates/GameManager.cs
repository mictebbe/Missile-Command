using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum ScoreState : int { missileDestroyed = 0, heliDestroyed = 1, missileLeft = 2, cityLeft = 3 };

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

	private const int citiesCount = 6;
	private List<bool> citiesDestroyed = new List<bool>();

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

		for (var i = 0; i < citiesCount; ++i)
		{
			citiesDestroyed.Add(false);
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

	// check if all cities are destroyed
	public bool isDestroyed()
	{
		foreach (bool cityDestroyed in citiesDestroyed) {
			if(!cityDestroyed)
			{
				return false;
			}
		}
		return true;
	}

	public void destroyCity(GameObject cityToDestroy)
	{
		var name = cityToDestroy.name;
		var cityIndex = name.Substring(name.Length - 1, 1);
		int idx = Convert.ToInt32(cityIndex) - 1;
		
		citiesDestroyed[idx] = true;
	}

	public bool isCityDestroyed(GameObject cityToDestroy)
	{
		var name = cityToDestroy.name;
		var cityIndex = name.Substring(name.Length - 1, 1);
		int idx = Convert.ToInt32(cityIndex) - 1;

		return citiesDestroyed[idx];
	}

	public void goToMenu()
	{
		LevelGenerator.Instance.showStartScreen();
	}

	public void addToScore(ScoreState state)
	{
		switch (state)
		{
			case ScoreState.missileDestroyed:
				this.score += 25;
				Debug.Log("Enemy Missile destroyed");
				break;
			case ScoreState.heliDestroyed:
				this.score += 50;
				break;
			case ScoreState.missileLeft:
				this.score += 10;
				break;
			case ScoreState.cityLeft:
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
		foreach(bool cityDestroyd in citiesDestroyed)
		{
			if(cityDestroyd == false)
			{
				addToScore(ScoreState.cityLeft);
			}
		}
		
		//Count Friendly missile Scores
		for (int i = 0; i < friendlyMissilesLiving; i++)
		{
			addToScore(ScoreState.missileLeft);
		}

	}

	void Update()
	{
		if (isDestroyed())
		{
			endGame();
		}
		var leftEnemyMissiles = GameObject.Find("MissilesEnemy").transform.childCount;
		if (leftEnemyMissiles <= 0)
		{
			goToNextLevel();
		}
	}

	void reviveCity()
	{
		foreach(bool cityDestroyd in citiesDestroyed)
		{
			if (!cityDestroyd)
			{
				addToScore(ScoreState.cityLeft);
			}
		}

		//Pick random City
		for (var i = 0; i < citiesCount; ++i)
		{
			int randomCityIdx = UnityEngine.Random.Range(0, citiesDestroyed.Count);
			bool cityToRevive = citiesDestroyed[randomCityIdx];

			if (citiesDestroyed[randomCityIdx] == true)
			{
				citiesDestroyed[randomCityIdx] = false;
				break;
			}
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
		return 1.0f + 0.1f * activeLevel;
	}
}