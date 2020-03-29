using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyedButton : MonoBehaviour
{
    public KeyCode keyName = KeyCode.Space;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyName)) {
            Click();
        }
    }

    public void Click() {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.Invoke();
    }
}
