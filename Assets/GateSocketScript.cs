using UnityEngine;
using System.Collections;

public class GateSocketScript : MonoBehaviour {

	//public Transform inputA;
	//public Transform inputB;
	public bool output;

    public bool locked;

    bool haveGate = false;

	public GateSocketScript inA;
	public GateSocketScript inB;
	public ConnectionLineDrawer outputLine;

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
		output = false;
		//inA = inputA.GetComponent<GateSocketScript>();
		//inB = inputB.GetComponent<GateSocketScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (haveGate)
		{
			bool inputA = false;
			bool inputB = false;

			if (inA != null)
				inputA = inA.output;
			if (inB != null)
				inputB = inB.output;

			output = gate.transform.GetComponent<GateObjectScript>().doGate(inputA, inputB);
		} else
		{
			output = false;
		}
        if (outputLine != null)
		    outputLine.changeState(output);
	}

    public bool hasGate()
    {
        return haveGate;
    }

    public GameObject unsocket()
    {
        if (locked)
            return null;
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
        if (locked)
            return false;

        obj.transform.SetParent(transform);
        Vector3 loc = transform.TransformPoint(new Vector3 (0, 1, 0));
        gate = obj;
        gate.transform.position = loc;
        gate.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        haveGate = true;

        return true;
    }
}
