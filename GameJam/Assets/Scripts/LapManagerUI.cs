using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LapManager))]
public class LapManagerUI : MonoBehaviour {

	// Use this for initialization
	LapManager m_lapManager;
	public Text lapTimeText;
	void Awake () {
		m_lapManager = GetComponent<LapManager>();
		//lapTimeText = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateLapTimeText();
	}
	
	void UpdateLapTimeText() {
		lapTimeText.text = "Current: " + SecondsToTime(m_lapManager.currentLapTime) + "\n" 
			+ "Last: " + SecondsToTime(m_lapManager.lastLapTime) + "\n" 
			+ "Best: " + SecondsToTime(m_lapManager.bestLapTime);
	}

	private string SecondsToTime(float seconds) {
		
		int displayMinutes = Mathf.FloorToInt(seconds / 60f);
		int displaySeconds = Mathf.FloorToInt(seconds % 60);
		int displayFractionSeconds = Mathf.FloorToInt((seconds - displaySeconds) * 100f);

		return displayMinutes + ":" + displaySeconds.ToString("00") + ":" + displayFractionSeconds.ToString("00");

	}
}
