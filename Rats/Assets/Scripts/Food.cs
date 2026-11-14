using UnityEngine;

public class Food : MonoBehaviour
{
    int foodType = 0;

    public int FoodType
    {
        get { return foodType; }
        set { foodType = value; }
    }

    public virtual void Interact()
    {

    }
}
