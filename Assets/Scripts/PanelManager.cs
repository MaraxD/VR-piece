using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    public List<PanelModel> panels;
    private PanelModel _currentPanel;

    public void ShowPanel(int panelID) {
        Debug.Log("show panel");

        if(_currentPanel != null) {
            return;
        }
        
        PanelModel panelModel = panels.FirstOrDefault(panel => panel.panelID == panelID);

        if(panelModel == null) {
            Debug.LogError($"Panel = {panelID} does not exist");
            return;
        }

        var newInstance = Instantiate(panelModel.prefab, transform);

        _currentPanel = new PanelModel{
            panelID = panelID,
            prefab = newInstance
        };
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
