using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PanelChanger : MonoBehaviour
{
    private Dictionary<PanelUpdater, GameObject> panels = new Dictionary<PanelUpdater, GameObject>();
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePanel(PanelUpdater node) {
        GameObject newPanel = node.GetNewPanel();
        newPanel.transform.SetParent(transform, false);
        panels[node] = newPanel;
    }

    public void RemovePanel(PanelUpdater node) {
        Destroy(panels[node]);
        panels.Remove(node);
    }

    public bool HasBuilding() {
        return panels.Count > 0;
    }
}