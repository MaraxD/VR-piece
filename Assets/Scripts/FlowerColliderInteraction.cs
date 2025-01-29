using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowerColliderInteraction : MonoBehaviour
{
    private PanelManager panelManager;
    private void Start()
    {
        panelManager = PanelManager.Instance;
        Debug.Log("flower created");
	}

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
	{
        Debug.Log("flower triggered");
        panelManager.ShowPanel(0);

    }
}