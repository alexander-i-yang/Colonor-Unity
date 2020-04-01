using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gamekit2D;

public class SwitchPanelUpdater : PanelUpdater
{
    public GameObject modifyOnPress;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override GameObject GetNewPanel() {
        GameObject p = base.GetNewPanel();
        ArgHolder holder = p.GetComponentInChildren<ArgHolder>();
        holder.methodName = "hello";
        return p;
    }
}