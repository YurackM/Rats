using UnityEngine;

public class RatFoodBar : MonoBehaviour
{
    [SerializeField] FoodBarFill foodBar;
   [SerializeField] float currentFood;
   [SerializeField] float maxFood = 1;
   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
       currentFood = 0;
       foodBar.UpdateFoodBar(currentFood, maxFood);
   }


   // Update is called once per frame
   void Update()
   {
      currentFood = gameObject.GetComponent<RatInteraction>().EatTimer;
      foodBar.UpdateFoodBar(currentFood, maxFood);
   }
}
