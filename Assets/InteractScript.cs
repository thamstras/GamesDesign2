using UnityEngine;
using System.Collections;

public class InteractScript : MonoBehaviour {

	Camera mainCam;

	// Use this for initialization
	void Start () {
		mainCam = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Interact"))
		{
			Vector3 origin = mainCam.transform.position;
			Vector3 direction = mainCam.transform.forward;
			Ray ray = new Ray(origin, direction);
			RaycastHit rayHit = new RaycastHit();
            if (Physics.Raycast(ray, out rayHit, 2.0f))
            {
                if (rayHit.collider.CompareTag("ButtonObject"))
                {
                    buttonScript button = rayHit.transform.GetComponent<buttonScript>();
                    button.press();
                }
            }
		}
	}
}
