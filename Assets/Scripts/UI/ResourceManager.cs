using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
public enum BaseResources {
    Crystal,
    Energy,
    Population,
    Tech
}
public class ResourceManager : MonoBehaviour
{
    private List<Resource> resources = new List<Resource>();
    void Start()
    {
        foreach (Transform child in transform)
            resources.Add(child.GetComponent<Resource>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetVal(BaseResources index) {
        return resources[(int)index].GetVal();
    }

    public bool CanBuy(List<Rsc> costs) {
        bool ret = true;
        foreach (Rsc cost in costs) {
            int costVal = cost.val;
            int currentVal = resources[(int)cost.index].val;
            if (costVal > currentVal) {
                ret = false;
            }
        }
        return ret;
    }

    public bool Buy(List<Rsc> costs) {
        bool ret = CanBuy(costs);
        if(ret) {
            foreach (Rsc cost in costs) {
                int costVal = cost.val;
                Resource curResource = resources[(int)cost.index];
                curResource.val -= costVal;
                curResource.UpdateText();
            }
        }
        return ret;
    }
}
