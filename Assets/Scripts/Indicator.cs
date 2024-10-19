using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Image indicatorImage; // Reference to the UI Image component
    public RectTransform indicatorRectTransform; // RectTransform of the indicator for positioning

    void Start()
    {
        // Log if the references are assigned
        Debug.Log("Indicator Image Assigned: " + (indicatorImage != null));
        Debug.Log("Indicator RectTransform Assigned: " + (indicatorRectTransform != null));

        // Initially hide the indicator
        HideIndicator();
    }


    // Method to update the skillshot indicator
    public void UpdateIndicator(Vector3 worldPosition)
    {
        // Convert the world position to screen position
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

        // Set the indicator's position based on the mouse position
        indicatorRectTransform.position = screenPosition;
        indicatorImage.gameObject.SetActive(true); // Show the indicator
    }

    // Method to hide the indicator
    public void HideIndicator()
    {
        indicatorImage.gameObject.SetActive(false); // Hide the indicator
    }
}
