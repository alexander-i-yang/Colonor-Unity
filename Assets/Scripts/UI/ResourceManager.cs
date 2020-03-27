using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public ArrayList resources = new ArrayList();
    void Start()
    {
        foreach (Transform child in transform)
            resources.Add(child);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
