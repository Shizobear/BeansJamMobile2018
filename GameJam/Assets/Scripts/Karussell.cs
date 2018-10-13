using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karussell : MonoBehaviour {

	public float rotationSpeed = 15f; 

	void Update () {

		transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

	}
}
