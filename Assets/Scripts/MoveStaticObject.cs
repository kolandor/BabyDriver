using UnityEngine;

/// <summary>
/// Moving nonplayeble object control
/// </summary>
public class MoveStaticObject : MonoBehaviour
{
    /// <summary>
    /// Should the object move
    /// </summary>
    public bool Move = true;

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

    // Start is called before the first frame update
    void Start()
    {
        Speed = CommonMovementParameters.StaticObjectsSpeed;
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
        transform.Translate(MoveDirection * Time.deltaTime * Speed);
    }
}
