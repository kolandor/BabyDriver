using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : MonoBehaviour
{
    public bool Rotate = true;

    public float RotationSpeed = 10f;

    public Vector3 Rotation = Vector3.zero;

    public bool DetectCollision = true;

    private GameObject _playerDetected = null;

    private Quaternion _baseRotation;

    // Start is called before the first frame update
    void Start()
    {
        _baseRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerDetected)
        {
            transform.LookAt(_playerDetected.transform);
        }
        else
        {
            if (Rotate)
            {
                transform.Rotate(Rotation * Time.deltaTime * RotationSpeed);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(DetectCollision)
        {
            GameObject detectedObject = other.gameObject;
            if(detectedObject.GetComponent<PlayerControllers>())
            {
                _playerDetected = detectedObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject detectedObject = other.gameObject;
        if (detectedObject.GetComponent<PlayerControllers>())
        {
            _playerDetected = null;
            transform.rotation = _baseRotation;
        }
    }
}
