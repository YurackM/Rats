using UnityEngine;
using UnityEngine.InputSystem;

public class RatInteraction : MonoBehaviour
{
    [SerializeField]
    private int preferredFoodType;
    private int fullness = 100;
    private float timer = 0f;
    private bool inRange;
    private Food nearestFood;
    private bool eating;
    private float eatTimer;

    public int PreferredFoodType { get; }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.2f)
        {
            timer -= 0.2f;
            fullness--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            nearestFood = collision.gameObject.GetComponent<Food>();
            inRange = true;
            if (nearestFood.FoodType == preferredFoodType)
                fullness += 10;
            else
            {
                fullness -= 3;
            }
            //Destroy(nearestFood.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Food>() == nearestFood)
            inRange = false;
    }


    // Still fixing
    private void Eat(InputAction.CallbackContext ctx)
    {
        if (!(inRange && ctx.started || eating))
            return;
        if (ctx.started)
            eating = true;

    }

}
