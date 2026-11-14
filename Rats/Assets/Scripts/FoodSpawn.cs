using UnityEngine;
using System.Collections.Generic;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab;
    Material cheese;
    int foodSpawnCount;
    List<GameObject> foodList = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < foodSpawnCount; i++)
        {
            int foodType = Random.Range(0, 4);
            
            if(foodType == 0)
            {
                foodList.Add(Instantiate());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
