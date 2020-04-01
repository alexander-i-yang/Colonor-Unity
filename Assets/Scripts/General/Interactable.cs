using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade() {
        Debug.Log("upgrade!");
    }

    internal bool HasOverlap()
    {
        throw new NotImplementedException();
    }
}