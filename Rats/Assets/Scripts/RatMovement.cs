using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class RatMovement : MonoBehaviour
{
    [SerializeField]float speed;
    Vector2 direction;
    Vector2 velocity;
    Vector2 position;
    Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        velocity = direction * speed;
        position += (velocity * Time.fixedDeltaTime);
        body.MovePosition(position);
    }

    public void OnPlayerMovement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        direction.Normalize();
    }
}
