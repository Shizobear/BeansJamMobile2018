using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour
{



    public float currentLapTime
    {
        get
        {
            if (m_isLapStated == false)
            {
                return 0f;
            }

            return Time.realtimeSinceStartup - m_currentLapStartTime;
        }
    }
    public float lastLapTime { get; private set; }
    public float bestLapTime { get; private set; }
    bool m_isLapStated = false;
    float m_currentLapStartTime;

    public int lapCounter = 0;
    public int lapsNeeded = 3;
    public float levelTimeRequirement = 60f;

    private Collider2D collision;
    public LayerMask playerLayer;
    private Transform m_transform;
    private BoxCollider2D hitbox;
    public Transform upperLeft;
    public Transform bottomRight;

    private void Start()
    {
        m_transform = this.gameObject.GetComponent<Transform>();
        hitbox = this.gameObject.GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        CheckForCollision();
    }
    private void CheckForCollision()
    {

        // collision = Physics2D.OverlapArea(upperLeft.position, bottomRight.position, playerLayer);

        // if (collision != null)
        // {
        //     Debug.Log(collision.name);
        //     OnCollision(collision);
        // }
    }

    private void OnCollision(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            Vector3 _position = other.gameObject.GetComponent<Transform>().position;

            if (m_transform.position.y < _position.y)
            {
                Debug.Log("von oben");

                lapCounter -= 1;
                if (lapCounter < 0)
                    lapCounter = 0;
                return;
            }


            if (m_isLapStated == true)
            {
                lastLapTime = Time.realtimeSinceStartup - m_currentLapStartTime;

                if (lastLapTime < bestLapTime || bestLapTime == 0f)
                {
                    bestLapTime = lastLapTime;
                }
            }

            m_isLapStated = true;
            m_currentLapStartTime = Time.realtimeSinceStartup;
            if (lapCounter < lapsNeeded)
            {
                lapCounter++;
            }
            else
            {
                if (bestLapTime < levelTimeRequirement)
                {
                    Debug.Log("Hier muss was passieren. EndScreen oder Level wechseln wenn die bedingung geschafft wurde");
                }
                else
                {
                    Debug.Log("Nicht geschafft du Kacklappen");
                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnCollision(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
     
    }
}
