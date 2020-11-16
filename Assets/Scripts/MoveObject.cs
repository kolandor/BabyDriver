using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// This script allows you to control 
/// the movement of an object associated with it
/// </summary>
public class MoveObject : MonoBehaviour
{
    /// <summary>
    /// Target position to which the object is moving
    /// </summary>
    public Transform TargetPosition;

    /// <summary>
    /// Automatic object movement
    /// </summary>
    public bool Move = false;

    /// <summary>
    /// Object movement by pressing the key
    /// </summary>
    public bool MoveByKey = false;

    /// <summary>
    /// The button by pressing which the object will move
    /// </summary>
    public KeyCode MoveKey = KeyCode.Space;

    /// <summary>
    /// Object speed
    /// </summary>
    public float Speed = 1;

    /// <summary>
    /// Self-destruct upon reaching the target
    /// </summary>
    public bool SelfDeleteObjectByGoalTrget = false;

    /// <summary>
    /// Distance at which the target is considered reached
    /// </summary>
    public float GoalDistanceFromTargetEvent = 0.5f;

    /// <summary>
    /// Time after which the object will self-destruct
    /// </summary>
    public float SelfDeleteTimeByGoalTrget = 0f;

    /// <summary>
    /// Goto Good Game scene
    /// </summary>
    public bool GoToGoodGameSceneByGoalTrget = true;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (TargetPosition != null)
        {
            //The condition is true if
            if (Move //The object moves automatically
                ^ (MoveByKey //Or allowed movement by pressing the key
                && Input.GetKey(MoveKey)))//And the key is pressed
            {//If movement is allowed and movement is allowed by pressing the key, 
             //then the object moves until the key is pressed according to the XOR condition

                //turn to the object face (along the Z axis)
                ExpandToTarget();


                if (MoveObjectToTarget() <= GoalDistanceFromTargetEvent)
                {
                    if (SelfDeleteObjectByGoalTrget)
                    {
                        Destroy(gameObject, SelfDeleteTimeByGoalTrget);
                    }
                    
                    if (GoToGoodGameSceneByGoalTrget)
                    {
                        SceneManager.LoadScene("GoodGame");
                        //Invoke("GoodGameScene", SelfDeleteTimeByGoalTrget);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Goto GG scene
    /// </summary>
    private void GoodGameScene()
    {
        SceneManager.LoadScene("GoodGame");
    }

    /// <summary>
    /// Turn to the object face (along the Z axis)
    /// </summary>
    private void ExpandToTarget()
    {
        transform.LookAt(TargetPosition);
    }

    /// <summary>
    /// Object and target movement
    /// </summary>
    /// <returns>Remaining distance to the target</returns>
    private float MoveObjectToTarget()
    {
        //the position of the object to which the script is attached
        Vector3 positionFrom = transform.position;
        //target position
        Vector3 positionTo = TargetPosition.position;
        //calculation of object speed relative to frame rate
        float currentSpeed = Time.deltaTime * Speed;

        //Moving an object to a goal
        transform.position = Vector3.MoveTowards(
            positionFrom, positionTo, currentSpeed);

        //distance between object and target
        return Vector3.Distance(positionFrom, positionTo);
    }
}