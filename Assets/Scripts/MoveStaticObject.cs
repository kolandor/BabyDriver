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

    /// <summary>
    /// Movement direction
    /// </summary>
    public Vector3 MoveDirection = Vector3.zero;

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
        transform.Translate(MoveDirection * Time.deltaTime * CommonGameData.StaticObjectsSpeed);
    }
}
