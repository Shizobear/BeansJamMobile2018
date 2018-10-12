using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : PlayerInputBase {

	private void Update()
	{
		UpdateSteering();
		UpdateEngineForce();
	}
	void UpdateSteering() {
		SetSteeringDirection( -Input.GetAxisRaw("Horizontal") );
	}

	void UpdateEngineForce() {
		SetEngineForce( Input.GetAxisRaw("RightVertical"));
	}
}
