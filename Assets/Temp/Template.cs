using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;

public class Template : MonoBehaviour {

    [SerializeField]
    private LayerMask blacklistLayers;

    public UnityEvent onEnter;
    public UnityEvent onExit;
    [SerializeField]
    private GameObject finalObject;

    private Vector2 mousePos;

	// Update is called once per frame
	void Update ()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(RoundToNearest(mousePos.x, 4.0f), RoundToNearest(mousePos.y, 4.0f));

        if (Input.GetMouseButtonDown(0)) {
            
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (ValidCollider(col)) onEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (ValidCollider(col)) onExit.Invoke();
    }

    bool ValidCollider(Collider2D col) {
        return blacklistLayers == (blacklistLayers | (1 << col.gameObject.layer));
    }

    float RoundToNearest(float f, float nearest) {
        return (float)(System.Math.Round(f * nearest, MidpointRounding.AwayFromZero) / nearest);
    }

    public void Hello() { Debug.Log("Hello!"); }
}