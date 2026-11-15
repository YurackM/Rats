using UnityEngine;

public class ChangeVisability : MonoBehaviour
{
    public GameObject item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOffRenderer()
    {
        item.gameObject.SetActive(!item.gameObject.activeSelf);
    }
}
