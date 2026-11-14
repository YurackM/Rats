using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class RatMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float tailLength;
    [SerializeField] GameObject parent;
    public Vector3 direction {get; set;}
    public bool isAtEnd {get; set;}
    Vector3 velocity, position, newPosition;
    Rigidbody2D rat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rat = GetComponent<Rigidbody2D>();
        position = transform.position;
        isAtEnd = false;
    }

    private void FixedUpdate()
    {
        velocity = direction * speed;
        newPosition = position + (velocity * Time.fixedDeltaTime);
        if(Vector3.Distance(newPosition, parent.transform.position) < tailLength){
            Debug.Log(Vector3.Distance(newPosition, parent.transform.position));
            position += (velocity * Time.fixedDeltaTime);
            rat.MovePosition(position);
            isAtEnd = false;
            //Debug.Log("move position");
        }
        else{
            isAtEnd = true;
        }
    }

    public void OnPlayerMovement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        direction.Normalize();
    }
}
