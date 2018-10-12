using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInputBase : MonoBehaviour {

	// Use this for initialization
	private PlayerMovement m_Movement;
	protected Joystick joystickSteuer;
	protected Joystick joystickGas;
	
	void Awake () {
		
		m_Movement = GetComponent<PlayerMovement>();
		joystickSteuer = GameObject.FindGameObjectWithTag("SteuerStick").GetComponent<FixedJoystick>();
		joystickGas = GameObject.FindGameObjectWithTag("GasStick").GetComponent<FixedJoystick>();
	}
	
	protected void SetSteeringDirection(float _steeringDirection) {
		m_Movement.SetSteeringDirection(_steeringDirection);
	}

	protected void SetEngineForce(float _engineForce) {
		m_Movement.SetEngineForce(_engineForce);
	}
}
