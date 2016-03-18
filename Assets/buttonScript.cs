using UnityEngine;
using System.Collections;

public class buttonScript : MonoBehaviour {

    public Vector3 offPosition;
    public Vector3 onPosition;
    public float onTime = 5.0f;
    public bool toggle = false;

    public bool state = false;

    private float timer = 0.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (state)
        {
            timer += Time.deltaTime;
            if (timer > onTime)
            {
                state = false;
            }
        }

        if (state)
        {
            transform.localPosition = onPosition;
        }
        else
        {
            transform.localPosition = offPosition;
        }
	}

    public void press()
    {
        if (!state)
        {
            timer = 0.0f;
            state = true;
        }
    }

}
