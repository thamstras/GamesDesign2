using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    public GateSocketScript socket;
    public Transform leftDoor;
    public Transform rightDoor;
    public bool open;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (open != socket.output)
        {
            open = socket.output;
            if (open)
            {
                leftDoor.localPosition = new Vector3(1.5f, 0.5f, 0.0f);
                rightDoor.localPosition = new Vector3(-1.5f, 0.5f, 0.0f);
            } else
            {
                leftDoor.localPosition = new Vector3(0.5f, 0.5f, 0.0f);
                rightDoor.localPosition = new Vector3(-0.5f, 0.5f, 0.0f);
            }
        }
	}
}
