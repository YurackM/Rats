using UnityEngine;

public class AIRats : Agent
{
    public float boundsWeight, time, circleRadius, seekWeight, wanderWeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override Vector3 CalcSteering()
    {
        totalForce = Vector3.zero;
        
        // if ()
        // {
        //     totalForce += Pursue(agentSO.itPlayer, time) * seekWeight;
        // }
        // else
        // {
        //     totalForce += Wander(time, circleRadius) * wanderWeight;
        // } 

        totalForce += Wander(time, circleRadius) * wanderWeight;
        
        totalForce += CheckBounds(0f) * boundsWeight;
        return totalForce;
    }

    
}
