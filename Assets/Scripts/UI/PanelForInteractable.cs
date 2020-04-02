using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelForInteractable : MonoBehaviour
{
    private Interactable interactable = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallObjectMethod(GameObject obj) {
        ArgHolder holder = obj.GetComponent<ArgHolder>();
        string methodName = holder.methodName;
        Arg[] args = holder.args;
        var methodCaller = typeof(Interactable).GetMethod(methodName);
        Debug.Log(methodName);
        methodCaller.Invoke(interactable, args);
    }

    public void SetInteractable(Interactable i) {interactable = i;}
}