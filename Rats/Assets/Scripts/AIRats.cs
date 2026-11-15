using UnityEngine;
using System.Collections.Generic;


public class AIRats : Agent
{
   public float boundsWeight, time, circleRadius, seekWeight, wanderWeight;
   public FoodSpawn foodspawn;


   // Start is called once before the first execution of Update after the MonoBehaviour is created
   protected override Vector3 CalcSteering()
   {
       totalForce = Vector3.zero;
       List<GameObject> foods = foodspawn.foodList;
       List<GameObject> ratFood = new List<GameObject>();
       foreach(GameObject f in foods){
           // if(f.GetComponent<Food>().FoodType == f.GetComponent<RatInteraction>().PreferredFoodType){
               if(f.transform.position.x < -screenHalfSize.x ||
                   f.transform.position.x > screenHalfSize.x ||
                   f.transform.position.y > screenHalfSize.y ||
                   f.transform.position.y < -screenHalfSize.y){
                   ratFood.Add(f);
               }
           // }
       }


       float nearestDistance = 1000000000;
       GameObject nearestFood = null;
       foreach(GameObject f in ratFood){
           if(nearestDistance > Vector3.Distance(f.transform.position, transform.position)){
               nearestDistance = Vector3.Distance(f.transform.position, transform.position);
               nearestFood = f;
           }
       }
       if(nearestFood != null)
       {
           totalForce += Seek(nearestFood) * seekWeight;
       }   
       else{
           totalForce += Wander(time, circleRadius) * wanderWeight;
       }


       totalForce += CheckBounds(0f) * boundsWeight;
       return totalForce;
   }


  
}
