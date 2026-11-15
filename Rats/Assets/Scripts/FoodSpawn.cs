using UnityEngine;
using System.Collections.Generic;


public class FoodSpawn : MonoBehaviour
{
   [SerializeField] GameObject foodPrefab;
   [SerializeField] int foodSpawnCount;
   [SerializeField] Sprite cheese;
   [SerializeField] Sprite apple;
   [SerializeField] Sprite pickle;
   [SerializeField] Sprite sushi;
   [SerializeField] Sprite wine;
   public List<GameObject> foodList = new List<GameObject>();
   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
       for(int i = 0; i < foodSpawnCount; i++)
       {
           int foodType = Random.Range(0, 5);
          
           if(foodType == 0)
           {
               GameObject food = Instantiate(foodPrefab, RandomLoaction(), Quaternion.identity);
               food.GetComponent<SpriteRenderer>().sprite = cheese;
               food.GetComponent<Food>().FoodType = 0;
               foodList.Add(food);
           }
           else if (foodType == 1)
           {
               GameObject food = Instantiate(foodPrefab, RandomLoaction(), Quaternion.identity);
               food.GetComponent<SpriteRenderer>().sprite = apple;
               food.GetComponent<Food>().FoodType = 1;
               foodList.Add(food);
           }
           else if (foodType == 2)
           {
               GameObject food = Instantiate(foodPrefab, RandomLoaction(), Quaternion.identity);
               food.GetComponent<SpriteRenderer>().sprite = sushi;
               food.GetComponent<Food>().FoodType = 2;
               foodList.Add(food);
           }
           else if (foodType == 3)
           {
               GameObject food = Instantiate(foodPrefab, RandomLoaction(), Quaternion.identity);
               food.GetComponent<SpriteRenderer>().sprite = pickle;
               food.GetComponent<Food>().FoodType = 3;
               foodList.Add(food);
           }
           else if (foodType == 4)
           {
               GameObject food = Instantiate(foodPrefab, RandomLoaction(), Quaternion.identity);
               food.GetComponent<SpriteRenderer>().sprite = wine;
               food.GetComponent<Food>().FoodType = 4;
               foodList.Add(food);
           }
       }
   }


   // Update is called once per frame
   void Update()
   {
      
   }


   Vector2 RandomLoaction()
   {
       Vector2 location = new Vector2(0, 0);
       location.x = Random.Range(-50f, 50f);
       location.y = Random.Range(-50f, 50f);
       return location;
   }
}


