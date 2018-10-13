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
		set {
			currentLapTime = value;
		}
		
    }
    public float lastLapTime { get; private set; }
    public float bestLapTime { get; private set; }
    bool m_isLapStated = false;
    float m_currentLapStartTime;

    public int lapCounter = 0;
    public int lapsNeeded = 3;
    public float levelTimeRequirement = 60f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {

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
                } else {
					Debug.Log("Nicht geschafft du Kacklappen");
				}
            }

        }
    }
}
