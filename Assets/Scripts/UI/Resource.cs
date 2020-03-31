using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resource : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mObject = null;
    public int val;
    public int incr;
    protected BaseResources index = BaseResources.Crystal;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateAll", 0.0f, 1.0f);
    }

    // Update is called once per frame
    private void Update() {}

    public void UpdateText() {
        mObject.text = $"{mObject.name} {val} (+{incr}/s)";
    }

    private void Increase() {
        val += incr;
    }

    private void UpdateAll() {
        Increase();
        UpdateText();
    }

    public TextMeshProUGUI GetObject() {return mObject;}
    
    public int GetVal() {return val;}

    public BaseResources GetIndex() {return index;}
}