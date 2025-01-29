using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowerColliderInteraction : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("flower created");

	}

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
	{
		Debug.Log("flower touched");
	}

}