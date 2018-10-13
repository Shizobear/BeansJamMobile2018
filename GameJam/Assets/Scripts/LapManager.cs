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
        }
    }
}
