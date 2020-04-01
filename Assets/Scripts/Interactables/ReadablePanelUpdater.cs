using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadablePanelUpdater : PanelUpdater
{
    public string text;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override GameObject GetNewPanel() {
        GameObject p = base.GetNewPanel();
        p.GetComponentInChildren<TextMeshProUGUI>().text = text;
        return p;
    }
}