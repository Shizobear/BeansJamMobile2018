using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public float smoothSpeed = .125f;
	public Vector3 offset;
	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	private void Start()
	{
		offset = new Vector3(0f, 0f, -10f);
	}
	private void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}

}
