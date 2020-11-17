using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public float XFrom = 0.5f;
    public float XTo = 1f;
    public float YFrom = 3f;
    public float YTo = 6f;
    public float ZFrom = 0.7f;
    public float ZTo = 2f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(Random.Range(XFrom, XTo), Random.Range(YFrom, YTo), Random.Range(ZFrom, ZTo));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
