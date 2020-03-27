using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PanelUpdater : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetNewPanel() {
        return PrefabUtility.InstantiatePrefab(panel as GameObject) as GameObject;
    }
}
