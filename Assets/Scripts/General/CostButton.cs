using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

[Serializable]
public class Rsc {
    public BaseResources index = BaseResources.Crystal;
    public int val;
    public int incr;
}

public class CostButton : MonoBehaviour {
    public List<Rsc> costs = new List<Rsc>();
    private List<Resource> trueCosts = new List<Resource>();
    private ResourceManager resources;
    public UnityEvent onClick = null;
    // Start is called before the first frame update
    void Start() {
        resources = GameObject.Find("Resources").GetComponent<ResourceManager>();
        Button b = GetComponent<Button>();
        b.onClick.AddListener(Clicked);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Clicked() {
        if (resources.Buy(costs)) {
            onClick.Invoke();
        } else {
            Debug.Log("You don't have enough resources");
        }
    }
}