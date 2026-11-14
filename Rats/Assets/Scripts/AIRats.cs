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
        foreach(GameObject f in foods){
            // if(f.GetComponent<Food>().FoodType == f.GetComponent<>()){

            // }
        }

        totalForce += Wander(time, circleRadius) * wanderWeight;
        
        totalForce += CheckBounds(0f) * boundsWeight;
        return totalForce;
    }

    
}
