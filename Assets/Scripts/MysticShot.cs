using UnityEngine;

public class MysticShot : MonoBehaviour
{
    public float speed = 15f; // Speed of the projectile
    public float range = 20f; // Maximum distance it can travel
    public float width = 0.5f; // Width of the projectile's hitbox
    public LayerMask hitLayers; // Define what layers the projectile can hit

    private Vector3 startPosition; // To track the starting point of the projectile

    void Start()
    {
        startPosition = transform.position; // Store the starting position

        // Set up a SphereCollider as the hitbox
        SphereCollider collider = gameObject.AddComponent<SphereCollider>();
        collider.radius = width / 2;
        collider.isTrigger = true;
    }

    void Update()
    {
        // Move the projectile forward at a constant speed
        transform.position += transform.forward * speed * Time.deltaTime;

        // Destroy the projectile if it exceeds its range
        if (Vector3.Distance(startPosition, transform.position) >= range)
        {
            Debug.Log("Mystic Shot destroyed due to range limit.");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug log when entering a collider
        Debug.Log("Mystic Shot entered collider: " + other.gameObject.name);

        // Check if the projectile hit an enemy (by checking the tag or layer)
        if (other.CompareTag("Enemy")) // Checking if the hit object is tagged as "Enemy"
        {
            // Debug log when hitting an enemy
            Debug.Log("Mystic Shot hit enemy: " + other.gameObject.name);

            // Destroy the enemy on contact
            Destroy(other.gameObject);

            // Destroy the projectile after hitting the enemy
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Mystic Shot hit an object that is not an enemy: " + other.gameObject.name);
        }
    }
}
