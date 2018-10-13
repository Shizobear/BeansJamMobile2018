﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	// Use this for initialization
	PlayerMovement m_Movement;

	private void Awake()
	{
		m_Movement = GetComponent<PlayerMovement>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//Debug.Log("Colliding with: " + collision.gameObject.name);

		if (collision.collider.CompareTag("Obstacle") == true) 
		{
			m_Movement.OnCollideWithObstacle();
			//Debug.Log("Colliding with: " + collision.gameObject.name);
		}
	}
}
