using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Gamekit2D;

delegate void NumberChanger(int n);

public class PanelUpdater : MonoBehaviour
{
    public GameObject panel;
    private PanelChanger panelToChange;
    // Start is called before the first frame update
    void Start()
    {
        GameObject buildings = GameObject.Find("Buildings");
        if (buildings != null) panelToChange = buildings.GetComponent<PanelChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBuildingEnter() {
        panelToChange.ChangePanel(this);
    }

    public void OnBuildingExit() {
        panelToChange.RemovePanel(this);
    }

    public void Hello() {
        Debug.Log("Hello world!");
    }

    public GameObject GetNewPanel() {
        GameObject p = PrefabUtility.InstantiatePrefab(panel as GameObject) as GameObject;
        p.GetComponent<PanelForInteractable>().SetInteractable(this.GetComponent<Interactable>());
        return p;
    }
}