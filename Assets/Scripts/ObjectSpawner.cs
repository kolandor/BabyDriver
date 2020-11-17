using UnityEngine;

/// <summary>
/// Generates objects in a line, designed to generate dangerous blocks
/// </summary>
public class ObjectSpawner : MonoBehaviour
{
    /// <summary>
    /// prefab object reference
    /// </summary>
    public GameObject SpawnedObjectPrefab;

    /// <summary>
    /// If the property is true objects are generated
    /// </summary>
    public bool Generate = true;

    /// <summary>
    /// Number of objects lined up
    /// </summary>
    public float ObjectsCount = 20f;

    /// <summary>
    /// Distance between generated objects
    /// </summary>
    public float DistanceBetweenObjects = 0f;

    /// <summary>
    /// Object line generation frequency in seconds
    /// </summary>
    public float SecondsSpawnFrequency = 2f;

    /// <summary>
    /// The probability of generating an object in 
    /// a cell of an object in one pass of the line in percent
    /// </summary>
    public int GenerationProbability = 3;

    // Start is called before the first frame update
    void Start()
    {
        //Creating a timer loop for generating objects
        InvokeRepeating("SpawnBlocks", 0, SecondsSpawnFrequency);
    }

    // Update is called once per frame
    private void SpawnBlocks()
    {
        if (Generate)
        {
            if (SpawnedObjectPrefab == null)
            {
                throw new System.Exception("DangerBlockPrefab link not found!");
            }

            //Colider size calculate from center, so this is half of objets size and i multiply it
            float zSizeOfObjest = SpawnedObjectPrefab.GetComponent<BoxCollider>().size.z * 2;

            for (float i = 0; i < ObjectsCount; i++)
            {
                //Generating an object if the generated number is lower or equal to the probability
                if (Random.Range(1, 100) <= GenerationProbability)
                {
                    float positionX = 0;
                    float positionY = 0;
                    //The calculation of the position of the object is based on the size of the object along 
                    //the Z axis and the distance between objects multiplied by the number of objects behind the Z axis
                    float positionZ = zSizeOfObjest * i + DistanceBetweenObjects * i;

                    Vector3 currentPosition = transform.TransformPoint(new Vector3(positionX, positionY, positionZ));

                    //Dynamic object generation
                    Instantiate(SpawnedObjectPrefab, currentPosition, SpawnedObjectPrefab.transform.rotation);
                }
            }
        }
    }
}