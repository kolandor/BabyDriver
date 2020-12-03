using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    public bool Move = true;

    /// <summary>
    /// Object speed
    /// </summary>
    public float Speed = 1;

    /// <summary>
    /// Distance at which the target is considered reached
    /// </summary>
    public float GoalDistanceFromTargetEvent = 0.5f;

    /// <summary>
    /// Time after which the object will self-destruct
    /// </summary>
    public float SelfDeleteTimeByGoalTrget = 0f;

    public bool isRight = false;
    public bool isLeft = false;

    private Sound _carEngineSound;
    private Sound _carEngineStartSound;

    // Start is called before the first frame update
    private void Start()
    {
        _carEngineStartSound = AudioManager.Manager.GetSound("CarEngineStart");
        _carEngineStartSound.Source.Play();
        _carEngineSound = AudioManager.Manager.GetSound("CarEngine");
    }

    // Update is called once per frame
    private void Update()
    {
        if (TargetPosition != null)
        {
            //The condition is true if
            if (Move)
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                if ((horizontalInput > 0f || isRight) && TargetPosition.position.x < 0.86f)
                {
                    float currentCarTargetSpeed = Time.deltaTime * (Speed + 0.5f);
                    TargetPosition.transform.Translate(Vector3.right * (Time.deltaTime * Speed));
                }
                if ((horizontalInput < 0f || isLeft) && TargetPosition.position.x > -0.86f)
                {
                    float currentCarTargetSpeed = Time.deltaTime * (Speed + 0.5f);
                    TargetPosition.transform.Translate(Vector3.left * (Time.deltaTime * Speed));
                }

                //turn to the object face (along the Z axis)
                ExpandToTarget();

                MoveObjectToTarget();

                if(!_carEngineStartSound.Source.isPlaying && !_carEngineSound.Source.isPlaying)
                {
                    _carEngineSound.Source.Play();
                }
            }
            else
            {
                _carEngineSound.Source.Stop();
            }
        }
    }

    public void Left()
    {
        isLeft = !isLeft;
    }

    public void Right()
    {
        isRight = !isRight;
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
        Vector3 positionTo = new Vector3(TargetPosition.position.x, TargetPosition.position.y, -6.246f);// TargetPosition.position;
        //calculation of object speed relative to frame rate
        float currentCarSpeed = Time.deltaTime * (Speed - 0.3f);

        //Moving an object to a goal
        transform.position = Vector3.MoveTowards(
            positionFrom, positionTo, currentCarSpeed);

        //distance between object and target
        return Vector3.Distance(positionFrom, positionTo);
    }
}