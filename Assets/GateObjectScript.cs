using UnityEngine;
using System.Collections;

public enum GateTypes { AND_GATE, OR_GATE, NOT_GATE, XOR_GATE, TRUE, FALSE, BUTTON };

public class GateObjectScript : MonoBehaviour {

	public GateTypes gateType;

    private buttonScript button;

    // Use this for initialization
    void Start() {
        if (gateType == GateTypes.BUTTON)
        {
            button = transform.GetComponentInChildren<buttonScript>();
			if (button == null)
				Debug.LogError("BUTTON DIDN'T FIND IT'S BUTTON!!!");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool doGate(bool inputA, bool inputB)
	{
		switch (gateType)
		{
			case GateTypes.AND_GATE:
				return inputA & inputB;
			case GateTypes.OR_GATE:
				return inputA | inputB;
			case GateTypes.NOT_GATE:
				return !inputA;
			case GateTypes.XOR_GATE:
				return inputA ^ inputB;
			case GateTypes.TRUE:
				return true;
			case GateTypes.FALSE:
				return false;
            case GateTypes.BUTTON:
                return button.state;
			default:
				return false;
		}
	}
}
