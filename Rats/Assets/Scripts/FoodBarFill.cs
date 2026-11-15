using UnityEngine;
using UnityEngine.UI;

public class FoodBarFill : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void UpdateFoodBar(float currentFood, float maxFood){
        fillImage.fillAmount = currentFood / maxFood;
    }
}
