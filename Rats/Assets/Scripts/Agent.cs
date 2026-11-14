using System.Data;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System;

public abstract class Agent : MonoBehaviour
{
    protected Vector3 velocity, acceleration, position, totalForce, steer, wanderPoint, wanderPosition;

    public float maxSpeed = 5f, maxForce = 3f, radius;
    public double angle;
    protected Vector2 screenHalfSize;
    public AgentSO agentSO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenHalfSize.y = Camera.main.orthographicSize;

        screenHalfSize.x = screenHalfSize.y * Camera.main.aspect;
        wanderPosition = new Vector3(UnityEngine.Random.Range(-1f, 1f),
            UnityEngine.Random.Range(-1f, 1f), 0);
        angle = Math.Atan(wanderPosition.normalized.y / wanderPosition.normalized.x);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject != null)
        {
            if (gameObject.CompareTag("Fox"))
            {
                // Zero out Acceleration from last frame
                acceleration = Vector3.zero;

                // Add Steering force to Acceleration
                acceleration += CalcSteering();
                //Debug.Log("Move?");
                gameObject.GetComponent<Rigidbody2D>().MovePosition(acceleration);
            }
            else
            {
                // Zero out Acceleration from last frame
                acceleration = Vector3.zero;

                // Add Steering force to Acceleration
                acceleration += CalcSteering();

                // Clamp force
                acceleration = Vector3.ClampMagnitude(acceleration, maxForce);

                steer = Vector3.ClampMagnitude(steer, maxForce);

                // Update Velocity with current Acceleration
                velocity += acceleration * Time.deltaTime;
                //  Move the agent with Velocity
                transform.position += velocity * Time.deltaTime;
            }
        }
        else
        {
            //Debug.Log("destroyed");
        }
        
    }

    protected abstract Vector3 CalcSteering();
    public Vector3 CalcFuturePosition(float time)
    {
        return transform.position + (velocity * time);
    }
    public Vector3 CheckBounds(float padding)
    {
        Vector3 force = Vector3.zero;
        // Check if out of bounds
        if(transform.position.x < -3f || 
            transform.position.x > 3f ||
            transform.position.y > 2f ||
            transform.position.y < -2f)
        {
            force = Seek(Vector3.zero);
        }
        return force;
    }

    public Vector3 Wander(float time, float circleRadius)
    {
        Vector3 circleCenter = CalcFuturePosition(time);

        double angleChange = UnityEngine.Random.Range((float)(Mathf.Deg2Rad * -5), (float)(Mathf.Deg2Rad * 5));
        
        angle = angle + angleChange;

        wanderPoint = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0);

        return Seek(wanderPoint * circleRadius + circleCenter);
    }
    public Vector3 Arrive(Vector3 targetPos)
    {
        //Vector3 desiredDirection = targetPos - transform.position;
        //float distance = desiredDirection.magnitude;
        Vector3 desiredVelocity = targetPos - transform.position;
        float distance = desiredVelocity.magnitude;

        if (distance < radius)
        {
            float newMag = Mathf.Lerp(0f, maxSpeed, Mathf.InverseLerp(0, radius, distance));
            desiredVelocity = newMag * desiredVelocity.normalized;            
        }
        else
        {
            desiredVelocity = maxSpeed * desiredVelocity.normalized;
        }

        steer = desiredVelocity - velocity;
        
        return steer;
    }
    public Vector3 Arrive(GameObject target)
    {
        return Arrive(target.transform.position);
    }
    public Vector3 Pursue(Agent target, float time)
    {
        return Seek(target.CalcFuturePosition(time));
    }
    public Vector3 Seek(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredDirection = targetPos - transform.position;

        // Set desired = max speed
        Vector3 desiredVelocity = desiredDirection.normalized * maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - velocity;

        // Return seek steering force
        return seekingForce;
    }
    public Vector3 Flee(Vector3 targetPos)
    {
        // Calculate desired direction
        Vector3 desiredDirection = transform.position - targetPos;

        // Set desired velocity = max speed * desired direction
        Vector3 desiredVelocity = desiredDirection.normalized * maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - velocity;

        // Return seek steering force
        return seekingForce;
    }
    public Vector3 Seek(GameObject target)
    {
        // Call the other version of Seek (returns
        // the seek steering force) and then return
        // that returned vector. 
        return Seek(target.transform.position);
    }
    public Agent FindNearest()
    {
        float distance = math.INFINITY;
        Agent tempAgent = null;
        foreach (Agent a in agentSO.agents)
        {
            if((transform.position - a.transform.position).magnitude < distance)
            {
                distance = (transform.position - a.transform.position).magnitude;
                tempAgent = a;
            }
        }
        return tempAgent;
    }
}
