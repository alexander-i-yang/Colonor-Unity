using UnityEngine;
using System;
using Gamekit2D;
using System.Collections;

[RequireComponent(typeof(Rigidbody), typeof(InteractOnTrigger2D))]
public class Placer : MonoBehaviour {

    public LayerMask ground;
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
        transform.position = new Vector2(RoundToNearest(mousePos.x, 2.0f), RoundToNearest(mousePos.y, 2.0f));

        if (Input.GetMouseButtonDown(0)) {
            if (!interactor.HasOverlap()) Instantiate(finalObject, transform.position, Quaternion.identity);
        }
    }

    float RoundToNearest(float f, float nearest) {
        return (float)(System.Math.Round(f * nearest, MidpointRounding.AwayFromZero) / nearest);
    }
    
    private Vector3 GetMousePos() {
        Vector3 point = new Vector3();
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = mainCamera.pixelWidth - Input.mousePosition.x;
        
        point = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, 0.0f, mainCamera.transform.position.z));

        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.down, distance: Mathf.Infinity, layerMask: ground);
        point.y = hit.point.y+GetComponent<SpriteRenderer>().size.y/2;
        return point;
    }
}