using UnityEngine;
using UnityEngine.UI;

public class HygieneBar : MonoBehaviour
{
   [SerializeField] private Image fillImage;


   public void UpdateHygieneBar(float currentHygiene, float maxHygiene)
   {
       fillImage.fillAmount = currentHygiene / maxHygiene;
   }
}
