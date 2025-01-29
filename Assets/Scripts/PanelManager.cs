using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    public Canvas panelRef;
    public TMP_Text text;
    public GameObject curvedCanvas;

    public void ShowPanel(string newText) {
        text.SetText(newText);
        curvedCanvas.SetActive(true);
        // curvedCanvas.transform.rotation = panelRef.worldCamera.transform.rotation;
    }

    public void ClosePanel() {
        curvedCanvas.SetActive(false);
    }
}
