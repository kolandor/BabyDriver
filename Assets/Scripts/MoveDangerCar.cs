using UnityEngine;

/// <summary>
/// Moving block object control
/// </summary>
public class MoveDangerCar : MonoBehaviour
{
    /// <summary>
    /// Should the object move
    /// </summary>
    public bool Move = true;

    /// <summary>
    /// Movement direction
    /// </summary>
    public Vector3 MoveDirection = Vector3.zero;

    /// <summary>
    /// Position of the target to the cortex the object is moving
    /// </summary>
    private float Speed = 1;

    /// <summary>
    /// Object movement speed
    /// </summary>
    public bool SelfDestroyByTime = true;

    /// <summary>
    /// Time after which the object will self-destruct
    /// </summary>
    public int SelfDestroyTime = 20;

    /// <summary>
    /// Use object rigidbody acceleration
    /// </summary>
    public bool UseForceForward = false;

    /// <summary>
    /// Acceleration moment
    /// </summary>
    public float AccelerationFactor = 1;

    // Start is called before the first frame update
    void Start()
    {
        Speed = CommonGameData.DangerCarsSpeed + Random.Range(0f, 1f);
        //self-destruct launch
        if (SelfDestroyByTime)
        {
            Destroy(gameObject, SelfDestroyTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {//If there is a goal, we move the object towards it
            MoveForward();
        }
    }

    void MoveForward()
    {
        //Add force to rigidBody (Requires improvement)
        //https://answers.unity.com/questions/769441/how-do-i-make-a-gameobject-accelerate.html
        if (UseForceForward)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * (Speed * AccelerationFactor));
        }
        else//Static object movement
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
    }
}