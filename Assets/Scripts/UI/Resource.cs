using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : TextMeshProGUI
{
    // Start is called before the first frame update
    public string name;
    public int val;
    public int incr;
    void Start()
    {
        val = 0;
        incr = 0;
        InvokeRepeating("UpdateText", 0.0f, 1.0f);
    }

    // Update is called once per frame
    private void Update() {}

    private void UpdateText()
    {
        Increase();
        text = $"{name} {val} (+{incr}/s)";
    }

    private void Increase() {
        val += incr;
    }
}
