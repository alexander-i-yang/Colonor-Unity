using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChanger : MonoBehaviour
{
    private Dictionary<PanelUpdater, GameObject> panels;
    // Start is called before the first frame update
    void Start() {
        panels = new Dictionary<PanelUpdater, GameObject>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePanel(PanelUpdater node) {
        GameObject newPanel = node.GetNewPanel();
        newPanel.transform.SetParent(transform, false);
        panels.Add(node, newPanel);
    }

    public void RemovePanel(PanelUpdater node) {
        Destroy(panels[node]);
        panels.Remove(node);
    }
}