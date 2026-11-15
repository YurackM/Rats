using UnityEngine;

public class RatVisuals : MonoBehaviour
{
    [SerializeField]GameObject ratTailKnot;
    [SerializeField]Sprite spriteLeft;
    [SerializeField] Sprite spriteRight;
    [SerializeField] Sprite spriteDown;
    [SerializeField] Sprite spriteUp;
    SpriteRenderer spriteRend;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookAngle = transform.position - ratTailKnot.transform.position;
        lookAngle.Normalize();
        if (Mathf.Abs(lookAngle.x / lookAngle.y) > 1f)
        {
            if(lookAngle.x > 0)
            {
                spriteRend.sprite = spriteRight;
            }
            else
            {
                spriteRend.sprite = spriteLeft;
            }

        }
        else
        {
            if(lookAngle.y > 0)
            {
                spriteRend.sprite = spriteUp;
            }
            else
            {
                spriteRend.sprite = spriteDown;
            }
        }
    }
}
