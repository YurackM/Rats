using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnableAIRats : MonoBehaviour
{
    public static bool enableAIRats = true;
    public TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enableAIRats = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AIRats()
    {
        enableAIRats = !enableAIRats;
        if (enableAIRats)
        {
            text.text = "AI Rats enabled";
        }
        else
        {
            text.text = "AI Rats disabled";
        }
    }
}
