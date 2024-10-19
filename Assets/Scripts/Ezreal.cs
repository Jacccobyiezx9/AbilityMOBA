using UnityEngine;
using UnityEngine.UI; // Needed for the Image component

public class Ezreal : MonoBehaviour
{
    public GameObject mysticShotPrefab; // The Mystic Shot prefab
    public Transform firePoint; // The point where the Mystic Shot is fired from
    public float shotCooldown = 1f; // Cooldown between shots
    public GameObject skillshotIndicator; // Reference to the UI Image for the skillshot indicator

    private float lastShotTime; // To track when the player can fire again
    private bool isIndicatorActive = false; // Track whether the indicator is active

    void Update()
    {
        // Toggle the indicator when Q is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isIndicatorActive = !isIndicatorActive; // Toggle the indicator state
            skillshotIndicator.gameObject.SetActive(isIndicatorActive); // Show or hide the indicator
        }

        // Update the position of the indicator if it is active
        if (isIndicatorActive)
        {
            UpdateIndicatorPosition(); // Update the position of the indicator
        }

        // Fire the Mystic Shot when the left mouse button is clicked
        if (Input.GetMouseButtonDown(0) && isIndicatorActive) // Fire only if the indicator is active
        {
            FireMysticShot();
        }
    }

    void UpdateIndicatorPosition()
    {
        // Position the indicator a fixed distance in front of the player
        float distanceFromPlayer = 2f; // Set this to however far you want the indicator to be from the player
        Vector3 indicatorPosition = transform.position + transform.forward * distanceFromPlayer; // Position in front of the player
        indicatorPosition.y = transform.position.y; // Keep the indicator at the player's height
        skillshotIndicator.transform.position = indicatorPosition; // Update position in world space
    }

    void FireMysticShot()
    {
        // Fire the Mystic Shot only if the cooldown has passed
        if (Time.time > lastShotTime + shotCooldown)
        {
            // Instantiate the Mystic Shot at the fire point's position and rotation
            Instantiate(mysticShotPrefab, firePoint.position, firePoint.rotation);
            lastShotTime = Time.time; // Update the last shot time
        }
    }
}
