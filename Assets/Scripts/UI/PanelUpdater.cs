// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;

// public class PanelUpdater : MonoBehaviour
// {
//     public GameObject panel;
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public GameObject GetNewPanel() {
//         return PrefabUtility.InstantiatePrefab(panel as GameObject) as GameObject;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Gamekit2D;

delegate void NumberChanger(int n);

public class PanelUpdater : MonoBehaviour
{
    public GameObject panel;
    public PanelChanger panelToChange = null;
    // Start is called before the first frame update
    void Start()
    {

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
        return PrefabUtility.InstantiatePrefab(panel as GameObject) as GameObject;
    }
}