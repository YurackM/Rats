using UnityEngine;
using UnityEngine.UI;


public class HungerBar : MonoBehaviour
{
   [SerializeField] private Image fillImage;


   public void UpdateHungerBar(float currentHunger, float maxHunger)
   {
       fillImage.fillAmount = currentHunger / maxHunger;
   }
}
