using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowerColliderInteraction : MonoBehaviour
{
    public string text;
    private PanelManager panelManager;
    private void Start()
    {
        panelManager = PanelManager.Instance;
	}

    void OnTriggerStay()
	{
        panelManager.ShowPanel(text);
    }
}