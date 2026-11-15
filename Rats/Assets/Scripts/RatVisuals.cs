using UnityEngine;

public class RatVisuals : MonoBehaviour
{
    [SerializeField]GameObject ratTailKnot;
    [SerializeField]GameObject ratTail;
    [SerializeField]Sprite spriteLeft;
    [SerializeField] Sprite spriteRight;
    [SerializeField] Sprite spriteDown;
    [SerializeField] Sprite spriteUp;
    [SerializeField] GameObject blood;
    SpriteRenderer spriteRend;
    bool dead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dead = false;
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

                float xScale = (Vector2.Distance(transform.position, ratTailKnot.transform.position) - 1.6f) * 0.25f;
                Vector3 currentScale = ratTail.transform.localScale;
                currentScale.x = xScale;
                ratTail.transform.localScale = currentScale;

                ratTail.transform.position = transform.position - (transform.localPosition / 2f);

                Vector3 angleFacing = ratTail.transform.rotation * new Vector3(1, 0, 0);
                Quaternion rotationNeeded = Quaternion.FromToRotation(angleFacing, transform.localPosition.normalized);
                ratTail.transform.rotation = rotationNeeded * ratTail.transform.rotation;
            }
            else
            {
                spriteRend.sprite = spriteLeft;

                float xScale = (Vector2.Distance(transform.position, ratTailKnot.transform.position) - 1.6f) * 0.25f;
                Vector3 currentScale = ratTail.transform.localScale;
                currentScale.x = xScale;
                ratTail.transform.localScale = currentScale;

                ratTail.transform.position = transform.position - (transform.localPosition / 2f);

                Vector3 angleFacing = ratTail.transform.rotation * new Vector3(1, 0, 0);
                Quaternion rotationNeeded = Quaternion.FromToRotation(angleFacing, transform.localPosition.normalized);
                ratTail.transform.rotation = rotationNeeded * ratTail.transform.rotation;
            }

        }
        else
        {
            if(lookAngle.y > 0)
            {
                spriteRend.sprite = spriteUp;

                float xScale = (Vector2.Distance(transform.position, ratTailKnot.transform.position) - 1.6f) * 0.25f;
                Vector3 currentScale = ratTail.transform.localScale;
                currentScale.x = xScale;
                ratTail.transform.localScale = currentScale;

                ratTail.transform.position = transform.position - (transform.localPosition / 2f);

                Vector3 angleFacing = ratTail.transform.rotation * new Vector3(1, 0, 0);
                Quaternion rotationNeeded = Quaternion.FromToRotation(angleFacing, transform.localPosition.normalized);
                ratTail.transform.rotation = rotationNeeded * ratTail.transform.rotation;
            }
            else
            {
                spriteRend.sprite = spriteDown;

                float xScale = (Vector2.Distance(transform.position, ratTailKnot.transform.position) - 1.6f) * 0.25f;
                Vector3 currentScale = ratTail.transform.localScale;
                currentScale.x = xScale;
                ratTail.transform.localScale = currentScale;

                ratTail.transform.position = transform.position - (transform.localPosition / 2f);

                Vector3 angleFacing = ratTail.transform.rotation * new Vector3(1, 0, 0);
                Quaternion rotationNeeded = Quaternion.FromToRotation(angleFacing, transform.localPosition.normalized);
                ratTail.transform.rotation = rotationNeeded * ratTail.transform.rotation;
            }
        }

        if (!dead && GetComponent<RatInteraction>().IsDead == true)
        {
            dead = true;
            blood.SetActive(true);
            spriteRend.flipY = true;
        }
    }
}
