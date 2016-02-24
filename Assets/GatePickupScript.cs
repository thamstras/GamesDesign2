using UnityEngine;
using System.Collections;

public class GatePickupScript : MonoBehaviour {

    Camera mainCam;

    Transform parent;

    public Vector3 attach;

    GameObject gate;

    bool haveGate = false;

	// Use this for initialization
	void Start () {
        mainCam = GetComponentInChildren<Camera>();
        parent = GetComponentInParent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Interact"))
        {
            Vector3 origin = mainCam.transform.position;
            Vector3 direction = mainCam.transform.forward;
            Ray ray = new Ray(origin, direction);
            RaycastHit rayHit = new RaycastHit();
            if (Physics.Raycast(ray, out rayHit, 100.0f))
            {
                if (rayHit.collider.gameObject.tag == "GateSocket")
                {
                    GateSocketScript socket = rayHit.collider.GetComponent<GateSocketScript>();
                    if (socket.hasGate())
                    {
                        GameObject gate = socket.unsocket();
                        gate.transform.SetParent(transform);
                        Vector3 loc = transform.TransformPoint(attach);
                        gate.transform.position = loc;
                        haveGate = true;
                    }
                }
            }
        }
	}
}
