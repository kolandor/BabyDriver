using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Enemy object control script that allows you to 
/// control the conditions for the destruction of the target
/// </summary>
public class EnemyObjectDestroyer : MonoBehaviour
{
    /// <summary>
    /// The name of the target object, the object on the scene 
    /// with this designation is tracked by the object to which 
    /// this script is attached
    /// </summary>
    public string TargetObjectName;

    /// <summary>
    /// Target reference
    /// </summary>
    private GameObject _targetObject;

    /// <summary>
    /// Target collision tracking
    /// </summary>
    public bool DetectGoalTrget = true;

    /// <summary>
    /// Whether to destroy the target on collision
    /// </summary>
    public bool DestroyTargetObjectByGoalTrget = true;

    /// <summary>
    /// Whether to destroy the script media object when the target is reached
    /// </summary>
    public bool SelfDestroyObjectByGoalTrget = false;

    /// <summary>
    /// The time after which the target and the object and the script media 
    /// object will be destroyed after a collision
    /// </summary>
    public float DestroyTimeByGoalTrget = 0f;

    /// <summary>
    /// Go to the game over screen
    /// </summary>
    public bool GoToGameOverByGoalTrget = true;

    /// <summary>
    /// Simulate car collision behavior
    /// </summary>
    public bool SimulationOfAnCarAccident = true;

    // Start is called before the first frame update
    private void Start()
    {
        if (!string.IsNullOrEmpty(TargetObjectName))
        {
            //Find and save a reference to a target
            _targetObject = GameObject.Find(TargetObjectName);
        }
    }

    // Update is called once per frame
    private void Update()
    {

    }

    /// <summary>
    /// Unity environment event that allows a reference to 
    /// the collider of the object with which the object 
    /// associated with the script collides at the time of the collision, 
    /// thereby allowing tracking of collisions
    /// </summary>
    /// <param name="other">Object collider collided with this object</param>
    private void OnTriggerEnter(Collider other)
    {

        if (DetectGoalTrget 
            &&_targetObject != null
            && other.gameObject.name == TargetObjectName)//If the name of the object this object collides with matches the target
        {
            AudioManager.Manager.Play("CarCrash");

            if (DestroyTargetObjectByGoalTrget)
            {
                Destroy(_targetObject, DestroyTimeByGoalTrget);
            }

            if (SimulationOfAnCarAccident)
            {
                CarCrashLogic();
            }

            if (SelfDestroyObjectByGoalTrget)
            {
                Destroy(gameObject, DestroyTimeByGoalTrget);
            }

            if (GoToGameOverByGoalTrget)
            {
                Invoke("ChangeScene", DestroyTimeByGoalTrget);
            }
        }
    }

    /// <summary>
    /// Simulate car collision behavior
    /// </summary>
    private void CarCrashLogic()
    {
        MoveObject move = _targetObject.GetComponent<MoveObject>();
        if (move != null)
        {
            CommonGameData.StaticObjectsSpeed = 0;
            move.Move = false;
            Invoke("StopEnemyCar", 0.5f);
        }
    }

    /// <summary>
    /// Delayed stopping of an enemy (this) car
    /// </summary>
    private void StopEnemyCar()
    {
        gameObject.GetComponent<MoveDangerCar>().Move = false;
    }

    /// <summary>
    /// Go to the game over screen
    /// </summary>
    private void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
