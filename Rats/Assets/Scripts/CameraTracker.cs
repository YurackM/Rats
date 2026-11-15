using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField]GameObject ratTail;
    [SerializeField]Vector3 screenBounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounds.y = Camera.main.orthographicSize / 2;
        screenBounds.x = (screenBounds.y * Camera.main.aspect);
        screenBounds.z = -10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

        if(ratTail.transform.position.x > (newPos.x + screenBounds.x))
        {
            float offset = (ratTail.transform.position.x - (newPos.x + screenBounds.x));
            newPos.x += offset;
        }
        else if (ratTail.transform.position.x < (newPos.x - screenBounds.x))
        {
            float offset = (ratTail.transform.position.x - (newPos.x - screenBounds.x));
            newPos.x -= Mathf.Abs(offset);
        }

        if (ratTail.transform.position.y > (newPos.y + screenBounds.y))
        {
            float offset = (ratTail.transform.position.y - (newPos.y + screenBounds.y));
            newPos.y += offset;
        }
        else if (ratTail.transform.position.y < (newPos.y - screenBounds.y))
        {
            float offset = (ratTail.transform.position.y - (newPos.y - screenBounds.y));
            newPos.y -= Mathf.Abs(offset);
        }

        transform.position = newPos;
    }
}
