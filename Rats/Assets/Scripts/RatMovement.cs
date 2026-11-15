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
    Rigidbody2D ratBody;
    RatInteraction ratInteract;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ratInteract = GetComponent<RatInteraction>();
        ratBody = GetComponent<Rigidbody2D>();
        position = transform.position;
        isAtEnd = false;
    }

    private void FixedUpdate()
    {
        if (ratInteract.IsDead)
            return;
        velocity = direction * speed;
        newPosition = transform.position + (velocity * Time.fixedDeltaTime);
        //Debug.Log(Vector3.Distance(newPosition, parent.transform.position));
        if (Vector3.Distance(newPosition, parent.transform.position) < tailLength){          
            ratBody.MovePosition(newPosition);
            isAtEnd = false;
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
