﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuGUI : MonoBehaviour
{

    string name = "";
    string score = "";
    List<Scores> highscore;

    // Use this for initialization
    void Start()
    {
        //EventManager.Instance._buttonClick += ButtonClicked;

        highscore = new List<Scores>();

    }


    void ButtonClicked(GameObject _obj)
    {
        print("Clicked button:" + _obj.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name :");
        name = GUILayout.TextField(name);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Score :");
        score = GUILayout.TextField(score);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Add Score"))
        {
            HighScoreManager.Instance.SaveHighScore(name, System.Int32.Parse(score));
            highscore = HighScoreManager.Instance.GetHighScore();
        }

        if (GUILayout.Button("Get LeaderBoard"))
        {
            highscore = HighScoreManager.Instance.GetHighScore();
        }

        if (GUILayout.Button("Clear Leaderboard"))
        {
            HighScoreManager.Instance.ClearLeaderBoard();
        }

        GUILayout.Space(60);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name", GUILayout.Width(Screen.width / 2));
        GUILayout.Label("Scores", GUILayout.Width(Screen.width / 2));
        GUILayout.EndHorizontal();

        GUILayout.Space(25);

        foreach (Scores _score in highscore)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(_score.name, GUILayout.Width(Screen.width / 2));
            GUILayout.Label("" + _score.score, GUILayout.Width(Screen.width / 2));
            GUILayout.EndHorizontal();
        }
    }
}

