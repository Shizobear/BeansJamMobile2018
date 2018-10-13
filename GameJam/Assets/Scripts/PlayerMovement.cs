
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Use this for initialization
    private Rigidbody2D playerRigidbody;
    public float maxEngineForce;
    public float maxReverseEngineForce;
    public float maxSteeringTorque;
    public float reversePower;
    public float acceleration;
    public float deceleation;
    private float m_engineForce = 0f;
    private float m_targetEngineForce = 0f;
    private float m_steeringDirection = 0f;
    public float maxSpeed = 15f;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateEngineForce();
    }
    private void FixedUpdate()
    {



        ApplyEngineForce();
        ApplySteeringForce();

        if (playerRigidbody.velocity.magnitude > maxSpeed)
        {
            playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxSpeed;
        }

        if (m_targetEngineForce < 0f && transform.InverseTransformDirection(playerRigidbody.velocity).y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * reversePower;
        }
        else if (m_targetEngineForce > 0f && transform.InverseTransformDirection(playerRigidbody.velocity).y < 0)
        {
			playerRigidbody.velocity = Vector2.zero;
        }
    }

    void UpdateEngineForce()
    {

        float _acceleration = acceleration;
        if (m_targetEngineForce == 0f)
        {
            _acceleration = deceleation;
        }
    
        m_engineForce = Mathf.MoveTowards(m_engineForce, m_targetEngineForce * maxEngineForce, _acceleration * Time.deltaTime);
    }

    void ApplyEngineForce()
    {
        float maximumEngineForce = maxEngineForce;

        if (m_engineForce < 0f)
        {
            maximumEngineForce = maxReverseEngineForce;
        }


        playerRigidbody.AddForce(transform.up * m_engineForce * maximumEngineForce, ForceMode2D.Force);

    }

    void ApplySteeringForce()
    {
        playerRigidbody.AddTorque(m_steeringDirection * maxSteeringTorque, ForceMode2D.Force);
    }

    public void SetSteeringDirection(float _steeringDirection)
    {
        m_steeringDirection = Mathf.Clamp(_steeringDirection, -1f, 1f);
    }

    public void SetEngineForce(float _engineForce)
    {
        m_targetEngineForce = Mathf.Clamp(_engineForce, -1f, 1f);
    }

    public void OnCollideWithObstacle()
    {
        m_engineForce = 0f;
    }

    public void OnCollideWithOil () {
        m_engineForce = 0f;
    }
}