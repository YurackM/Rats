using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RatInteraction : MonoBehaviour
{
    [SerializeField]
    private int preferredFoodType;
    private float timer = 0f;
    private bool inRange;
    private bool isDead;
    private float currentHunger = 100;
    private List<Food> nearbyFoods = new List<Food>();
    private Food nearestFood;
    private bool eating;
    private float eatTimer;
    private int cleanliness = 100;
    private bool cleaning;
    private float cleanTimer;

    public bool IsDead { get { return isDead; } }
    public int PreferredFoodType { get{return preferredFoodType;} }
    public float CurrentHunger {get{return currentHunger;}}
    public float CurrentCleanliness { get { return cleanliness; } }

    void Update()
    {
        if (isDead)
            return;

        // Timer
        timer += Time.deltaTime;
        if (timer > 0.3f)
        {
            timer -= 0.3f;
            currentHunger--;
            cleanliness--;
        }

        // Nearest Food
        if (nearbyFoods.Count > 0)
        {
            foreach (Food f in nearbyFoods)
            {
                if (nearestFood == null)
                    nearestFood = f;
                else if (Vector2.Distance(transform.position, f.transform.position) < Vector2.Distance(transform.position, nearestFood.transform.position))
                {
                    nearestFood = f;
                    eating = false;
                }
            }
        }

        // Eating food
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

        // Cleaning
        if (cleaning)
        {
            cleanTimer += Time.deltaTime;
            if (cleanTimer > 0.5f)
                EatFood();
        }
        else
        {
            cleanTimer = 0f;
        }

        // Life check
        if (currentHunger <= 0 || cleanliness <= 0)
            isDead = true;
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
            currentHunger += 10;
        else
        {
            currentHunger -= 3;
        }
        Destroy(nearestFood.gameObject);
        eating = false;
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


    public void Eat(InputAction.CallbackContext ctx)
    {
        if (!(inRange && ctx.started || eating))
            return;
        if (ctx.started)
            eating = true;
        if (ctx.canceled)
            eating = false;
    }

    public void Clean(InputAction.CallbackContext ctx)
    {
        if (!(inRange && ctx.started || cleaning))
            return;
        if (ctx.started)
            cleaning = true;
        if (ctx.canceled)
            cleaning = false;
    }

}
