using UnityEngine;

public class RatHunger : MonoBehaviour
{
    [SerializeField] HungerBar hungerBar;
    [SerializeField] float currentHunger;
    [SerializeField] float maxHunger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHunger = maxHunger;
        hungerBar.UpdateHungerBar(currentHunger, maxHunger);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
