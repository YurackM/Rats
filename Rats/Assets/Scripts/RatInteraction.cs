using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RatInteraction : MonoBehaviour
{
    [SerializeField]
    private int preferredFoodType;
    private int fullness = 100;
    private float timer = 0f;
    private bool inRange;
    private List<Food> nearbyFoods = new List<Food>();
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

        if (nearbyFoods.Count > 0)
        {

        }

        if (eating)
        {
            eatTimer += Time.deltaTime;
            if (eatTimer > 1f)
                EatFood();
        }
        else
        {
            eatTimer = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            nearbyFoods.Add(collision.gameObject.GetComponent<Food>());
            inRange = true;
            if (nearbyFoods.Count == 1)
                nearestFood = nearbyFoods[0];
        }
    }

    private void EatFood()
    {
        if (nearestFood.FoodType == preferredFoodType)
            fullness += 10;
        else
        {
            fullness -= 3;
        }
        Destroy(nearestFood.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            nearbyFoods.Remove(collision.gameObject.GetComponent<Food>());
        }
            //if (collision.gameObject.GetComponent<Food>() == nearestFood)

        if (nearbyFoods.Count == 0)
        {
            nearestFood = null;
            inRange = false;
            eating = false;
        }
    }


    // Still fixing
    public void Eat(InputAction.CallbackContext ctx)
    {
        if (!(inRange && ctx.started || eating))
            return;
        if (ctx.started)
            eating = true;
        if (ctx.canceled)
            eating = false;
    }

}
