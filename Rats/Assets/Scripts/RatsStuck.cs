using UnityEngine;

public class RatsStuck : MonoBehaviour
{
    [SerializeField]float maxDistance;
    [SerializeField]GameObject parentTail;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, parentTail.transform.position) > maxDistance)
        {
            Debug.Log("Pull Back");
        }
    }
}
