using UnityEngine;
using System.Collections.Generic;

public class RatKingMovement : MonoBehaviour
{
    [SerializeField] float speed, aiWeight;
    [SerializeField] GameObject rat1;
    [SerializeField] GameObject rat2;
    [SerializeField] GameObject rat3;
    [SerializeField] GameObject rat4;
    Vector3 velocity;
    Vector3 position;
    private List<GameObject> rats = new List<GameObject>();
    private List<GameObject> aiRats = new List<GameObject>();
    Rigidbody2D ratKing;
    bool move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = transform.position;
        rats.Add(rat1);
        rats.Add(rat2);
        aiRats.Add(rat3);
        aiRats.Add(rat4);
        ratKing = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(GameObject r in rats){
            if(r.GetComponent<RatMovement>().isAtEnd){
                move = true;
            }
        }
        foreach(GameObject ai in aiRats){
            if(ai.GetComponent<Agent>().isAtEnd){
                move = true;
            }
        }
        if(move){
            Movement();
            move = false;
        }
    }

    public void Movement(){
        Vector3 averageDirection = new Vector3();
        foreach(GameObject r in rats){
            if(r.GetComponent<RatMovement>().isAtEnd){
                averageDirection += r.GetComponent<RatMovement>().direction;
            }
        }
        foreach(GameObject ai in aiRats){
            if(ai.GetComponent<Agent>().isAtEnd){
                Vector3 aiDirection = -ai.GetComponent<Agent>().direction;
                averageDirection += aiDirection * aiWeight;
            }
        }
        
        velocity = averageDirection.normalized * speed;
        position += (velocity * Time.fixedDeltaTime);
        ratKing.MovePosition(position);
    }
}
