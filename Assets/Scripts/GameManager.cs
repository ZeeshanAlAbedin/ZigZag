using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour {



    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {

        UiManager.instance.GameStart();
        ScoreManager.instance.startScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
    }

    public void GameOver()
    {

     
        if (!gameOver)
        {

        
            ScoreManager.instance.StopScore();
            UiManager.instance.GameOver();

            //if authenticated then

            if (Social.localUser.authenticated)
            {
                LeaderBoardManager.instance.AddScoreToLeaderboard();
            }
          
         



            gameOver = true;
        }
    }
}
