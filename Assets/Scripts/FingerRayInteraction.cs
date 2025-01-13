using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerRayInteraction : MonoBehaviour
{
    public float raycastDistance = 0.1f;  // Adjust based on how far you want the interaction to happen

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Create a ray from the object's position in the forward direction
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Droplets"))
            {
                Debug.Log("Droplet hit!");

                // Example interaction: Destroy the droplet
                Destroy(hit.collider.gameObject);

                // You can add any custom interaction logic here
                // e.g., play a sound, spawn an effect, etc.
            }
        }

        // Optional: Debug line to visualize the raycast in the editor
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);
    }
}
