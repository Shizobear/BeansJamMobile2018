using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapLine : MonoBehaviour
{
    public int index;
    LapManager m_lapManager;

	private void Awake()
	{
		m_lapManager = GetComponentInParent<LapManager>();
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
			
		}
    }
}
