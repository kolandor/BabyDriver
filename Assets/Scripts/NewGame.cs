using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The new game is responsible for the logic of the screen
/// </summary>
public class NewGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Going to the scene with the game
            SceneManager.LoadScene("GameCarVsBlocks");
        }
    }
}
