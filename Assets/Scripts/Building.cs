using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private static List<Building> instanceList;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instanceList == null) instanceList = new List<Building>();
        instanceList.Add(this);
    }

    public static Building GetClosest(Vector2 position) {
        Building closest = null;

        for (int i = 0; i<instanceList.Count; i++) {
            if (closest == null) {
                closest = instanceList[i];
            } else {
                if (Vector2.Distance(position, instanceList[i].GetPosition())
                    < Vector2.Distance(position, closest.GetPosition())) {
                    closest = instanceList[i];
                }
            }
        }
        return closest;
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetPosition() {return transform.position;}
}