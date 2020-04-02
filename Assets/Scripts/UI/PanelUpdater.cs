using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using Gamekit2D;

delegate void NumberChanger(int n);

public class PanelUpdater : MonoBehaviour
{
    public GameObject panel;
    protected PanelChanger panelToChange;

    // Start is called before the first frame update
    protected void Start()
    {
        GameObject buildings = GameObject.Find("Buildings");
        if (buildings != null) panelToChange = buildings.GetComponent<PanelChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBuildingEnter() {
        GetPanelToChange().ChangePanel(this);
    }

    public void OnBuildingExit() {
        panelToChange.RemovePanel(this);
    }

    public virtual GameObject GetNewPanel() {
        GameObject p = PrefabUtility.InstantiatePrefab(panel as GameObject) as GameObject;
        p.GetComponent<PanelForInteractable>().SetInteractable(this.GetComponent<Interactable>());
        return p;
    }

    protected PanelChanger GetPanelToChange() {
        return panelToChange;
    }
}