using UnityEngine;

public class UIFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 worldOffset = new Vector3(0f, 2f, 0f);
    
    private Camera mainCamera;
    private RectTransform rectTransform;

    void Start()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Convert the player's world position + offset to screen coordinates
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(player.position + worldOffset);

        // Hide the UI image if the player is behind the camera
        if (screenPosition.z < 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            rectTransform.position = screenPosition;
        }
    }
}