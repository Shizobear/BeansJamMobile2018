using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputTouch : PlayerInputBase {

	
	private void Update()
	{
		UpdateSteering();
		UpdateEngineForce();
	}
	void UpdateSteering() {
		SetSteeringDirection( -joystickSteuer.Horizontal );
	}

	void UpdateEngineForce() {
		SetEngineForce( joystickGas.Vertical);
	}

}
