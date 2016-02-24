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
        gate.transform.SetParent(transform.parent);
        gate = null;
        haveGate = false;
        return temp;
    }
}
