using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasExplosion : MonoBehaviour
{
    public GameObject explosionEffect;  // Drag your explosion particle system prefab here
    public float explosionForce = 1000f;
    public float explosionRadius = 5f;
    public float upwardsModifier = 2f;

    private bool isExploded = false;  // This flag ensures the house only explodes once

    void OnCollisionEnter(Collision collision)
    {
        if (!isExploded && collision.gameObject.CompareTag("Explosive"))  // Ensure explosion only happens once
        {
            Explode(collision.gameObject);  // Pass the colliding object (explosive)
        }
    }

    void Explode(GameObject explosiveObject)
    {
        // Set the flag to true to prevent re-explosion
        isExploded = true;

        // Debug to ensure explosion is triggered only once
        Debug.Log("Explosion triggered");

        // Spawn explosion effect at the house's position
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // Apply explosion force to nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
            }
        }

        // Optional: Destroy the triggering object to prevent it from causing further explosions
        Destroy(explosiveObject);

        // Destroy the house object
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isExploded && other.CompareTag("Explosive"))
        {
            Explode(other.gameObject);  // Pass the object that triggered the explosion
        }
    }
}
