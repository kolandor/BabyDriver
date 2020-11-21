using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.TransformDirection(Vector3.forward * Time.deltaTime * CommonGameData.StaticObjectsSpeed);
    }
}
