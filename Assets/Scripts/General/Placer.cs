using UnityEngine;
using System;
using Gamekit2D;
using System.Collections;

[RequireComponent(typeof(Rigidbody), typeof(InteractOnTrigger2D))]
public class Placer : MonoBehaviour {

    [SerializeField]
    private GameObject finalObject;
    
    private Camera mainCamera;

    private InteractOnTrigger2D interactor;
    void Start() {
        GameObject cameraOb = GameObject.Find("MainCamera");
        if (cameraOb == null) cameraOb = GameObject.Find("Main Camera");
        if (cameraOb == null) cameraOb = GameObject.Find("Camera");
        mainCamera = cameraOb.GetComponent<Camera>();
        interactor = GetComponent<InteractOnTrigger2D>();
    }
    
	// Update is called once per frame
    void Update ()
    {
        Vector3 mousePos = GetMousePos();
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        if (Input.GetMouseButtonDown(0)) {
            if (!interactor.HasOverlap()) Instantiate(finalObject, transform.position, Quaternion.identity);
        }
    }

    float RoundToNearest(float f, float nearest) {
        return (float)(System.Math.Round(f * nearest, MidpointRounding.AwayFromZero) / nearest);
    }

    public void hello() {Debug.Log("hello!");}

    void OnGUI()
    {
        Vector3 point = new Vector3();
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = mainCamera.pixelWidth - Input.mousePosition.x;
        mousePos.y = mainCamera.pixelHeight - Input.mousePosition.y;

        point = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCamera.transform.position.z));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + mainCamera.pixelWidth + ":" + mainCamera.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }

    private Vector3 GetMousePos() {
        Vector3 point = new Vector3();
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = mainCamera.pixelWidth - Input.mousePosition.x;
        mousePos.y = mainCamera.pixelHeight - Input.mousePosition.y;

        point = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCamera.transform.position.z));
        return point;
    }
}