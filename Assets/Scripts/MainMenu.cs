using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(CommonGameData.PlayerScore > CommonGameData.MaxPlayerScore)
        {
            CommonGameData.MaxPlayerScore = CommonGameData.PlayerScore;
        }
        Text scoreText = GameObject.Find("TextScore").GetComponent<Text>();
        scoreText.text = $"Max Score: {CommonGameData.MaxPlayerScore}";
    }

    public void Game()
    {
        AudioManager.Manager.Play("ButtonCilick");
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        AudioManager.Manager.Play("ButtonCilick");
        Application.Quit(0);
    }
}
