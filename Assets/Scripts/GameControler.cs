using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Control common game processes
/// </summary>
public class GameControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CommonGameData.ResetValues();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("ScoreText").GetComponent<Text>().text = $"Score: {CommonGameData.PlayerScore += Time.deltaTime}";

        /*int score = ((int)CommonMovementParameters.PlayerScore);

        if (score > 0 && score % 10 == 0 && CommonMovementParameters.DangerCarsSpeed < 8f)
        {
            CommonMovementParameters.StaticObjectsSpeed += 0.2f;
            CommonMovementParameters.DangerCarsSpeed += 0.2f;
        }*/
    }
}
