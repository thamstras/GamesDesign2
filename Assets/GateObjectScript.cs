using UnityEngine;
using System.Collections;

public enum GateTypes { AND_GATE, OR_GATE, NOT_GATE, XOR_GATE, TRUE, FALSE };

public class GateObjectScript : MonoBehaviour {

	public GateTypes gateType;

	// Use this for initialization
	void Start () {
	
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
			default:
				return false;
		}
	}
}
