using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RatInteraction : MonoBehaviour
{
    [SerializeField] Image fillFood;
    private int preferredFoodType;
    private float timer = 0f;
    private bool inEatingRange;
    private bool inCleaningRange;
    private bool isDead;
    private float currentHunger = 100;
    private List<Food> nearbyFoods = new List<Food>();
    private Food nearestFood;
    private bool eating;
    private float eatTimer;
    private static int cleanliness = 400;
    private List<Collider2D> nearbyRats = new List<Collider2D>();
    private bool cleaning;
    private float cleanTimer;

    public bool IsDead { get { return isDead; } }
    public int PreferredFoodType { get{return preferredFoodType;} }
    public float CurrentHunger {get{return currentHunger;}}
    public float CurrentCleanliness { get { return cleanliness; } }
    public float EatTimer{get{return eatTimer;}}

    void Start()
    {
        cleanliness = 400;
    }

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
            fillFood.enabled = true;
            if (eatTimer > 1f){
                EatFood();
                fillFood.enabled = false;
            }
        }
        else
        {
            //fillFood.enabled = false;
            eatTimer = 0f;
        }

        // Cleaning
        if (cleaning)
        {
            cleanTimer += Time.deltaTime;
            if (cleanTimer > 0.5f)
                CleanRat();
        }
        else
        {
            cleanTimer = 0f;
        }

        // Limiting variables
        if (currentHunger > 100)
            currentHunger = 100;
        if (cleanliness > 400)
            cleanliness = 400;

        // Life check
        if (currentHunger <= 0 || cleanliness <= 0)
            isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            nearbyFoods.Add(collision.gameObject.GetComponent<Food>());
            inEatingRange = true;
            if (nearbyFoods.Count == 1)
                nearestFood = nearbyFoods[0];
            if (gameObject.CompareTag("AIRat"))
            {
                EatFood();
            }
        }

        else if (collision.gameObject.CompareTag("Rat") || collision.gameObject.CompareTag("AIRat"))
        {
            nearbyRats.Add(collision.gameObject.GetComponent<Collider2D>());
            inCleaningRange = true;
        }
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
            inEatingRange = false;
            eating = false;
        }

        if (collision.gameObject.CompareTag("Rat") || collision.gameObject.CompareTag("AIRat"))
        {
            nearbyRats.Remove(collision.gameObject.GetComponent<Collider2D>());
            inCleaningRange = false;
            cleaning = false;
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

    private void CleanRat()
    {
        cleanliness += 60;
        cleaning = false;
    }


    public void Eat(InputAction.CallbackContext ctx)
    {
        if (!(inEatingRange && ctx.started || eating))
            return;
        if (ctx.started)
            eating = true;
        if (ctx.canceled)
            eating = false;
    }

    public void Clean(InputAction.CallbackContext ctx)
    {
        if (!(inCleaningRange && ctx.started || cleaning))
            return;
        if (ctx.started)
            cleaning = true;
        if (ctx.canceled)
            cleaning = false;
    }

}
