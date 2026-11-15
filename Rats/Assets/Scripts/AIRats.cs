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
       foreach(GameObject f in foods)
       {
            if(f == null)
            {
                continue;
            }
            if(f.GetComponent<Food>().FoodType == gameObject.GetComponent<RatInteraction>().PreferredFoodType || f.GetComponent<Food>().FoodType == 4)
            {
               if(f.transform.position.x > -screenHalfSize.x + transform.position.x &&
                   f.transform.position.x < screenHalfSize.x + transform.position.x &&
                   f.transform.position.y < screenHalfSize.y + transform.position.y &&
                   f.transform.position.y > -screenHalfSize.y + transform.position.y){
                   ratFood.Add(f);
                }
           }
       }


       float nearestDistance = float.MaxValue;
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
           //Debug.Log(nearestFood.transform.position);
        }
        else
        {
            totalForce += Wander(time, circleRadius) * wanderWeight;
        }

        return totalForce;
   }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + direction);
    }

}
