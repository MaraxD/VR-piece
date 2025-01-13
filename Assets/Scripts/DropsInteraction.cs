using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsInteraction : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Droplets"))
        {
            Debug.Log("Touched a droplet!");
            // Add your interaction logic here (e.g., destroy droplet, play sound, etc.)
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
