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
        if(CommonMovementParameters.PlayerScore > CommonMovementParameters.MaxPlayerScore)
        {
            CommonMovementParameters.MaxPlayerScore = CommonMovementParameters.PlayerScore;
            GameObject.Find("TextScore").GetComponent<Text>().text = $"Max Score: {CommonMovementParameters.MaxPlayerScore}";
        }
    }

    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit(0);
    }
}
