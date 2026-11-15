using UnityEngine;

public class RatHygiene : MonoBehaviour
{
   [SerializeField] HygieneBar hygieneBar;
   [SerializeField] float currentHygiene;
   [SerializeField] float maxHygiene = 100;
   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
       currentHygiene = maxHygiene;
       hygieneBar.UpdateHygieneBar(currentHygiene, maxHygiene);
   }


   // Update is called once per frame
   void Update()
   {
      currentHygiene = gameObject.GetComponent<RatInteraction>().CurrentCleanliness;
      hygieneBar.UpdateHygieneBar(currentHygiene, maxHygiene);
   }
}
