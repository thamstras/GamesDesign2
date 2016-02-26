using UnityEngine;
using System.Collections;

public class GateSocketScript : MonoBehaviour {

    bool haveGate = false;

    GameObject gate;

	// Use this for initialization
	void Start () {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("GateObject"))
            {
                gate = child.gameObject;
                haveGate = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool hasGate()
    {
        return haveGate;
    }

    public GameObject unsocket()
    {
        GameObject temp = gate;
        gate.transform.SetParent(null);
        gate = null;
        haveGate = false;
        return temp;
    }

    public bool socket(GameObject obj)
    {
        if (haveGate)                                   // If we already have a gate return false
            return false;
        if (!obj.CompareTag("GateObject"))              // if its not a gate return false
            return false;
        if (obj.transform.parent != null)   // if the gate is parented to something return false
            return false;

        obj.transform.SetParent(transform);
        Vector3 loc = transform.TransformPoint(new Vector3 (0, 1, 0));
        gate = obj;
        gate.transform.position = loc;
        haveGate = true;

        return true;
    }
}
