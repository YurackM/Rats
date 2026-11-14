using UnityEngine;
using System.Collections.Generic;

public class RatKingMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject rat1;
    [SerializeField] GameObject rat2;
    //[SerializeField] GameObject rat3;
    //[SerializeField] GameObject rat4;
    Vector3 velocity;
    Vector3 position;
    private List<GameObject> rats = new List<GameObject>();
    Rigidbody2D ratKing;
    bool move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = transform.position;
        rats.Add(rat1);
        rats.Add(rat2);
        //rats.Add(rat3);
        //rats.Add(rat4);
        ratKing = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    public void Movement(){
        Vector3 averageDirection = new Vector3();
        foreach(GameObject r in rats){
            if(r.GetComponent<RatMovement>().isAtEnd){
                averageDirection += r.GetComponent<RatMovement>().direction;
            }
        }
        
        velocity = averageDirection.normalized * speed;
        position += (velocity * Time.fixedDeltaTime);
        ratKing.MovePosition(position);
    }
}
