using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private void Start()
	{
		PlayerPrefs.DeleteAll();
	}
	public void PlayGame() {
		SceneManager.LoadScene("LevelSelect");

	}

	public void QuitGame(){
		SceneManager.LoadScene("Credits");
	}

	public void Back(){
		SceneManager.LoadScene("Menu");
	}
	
}
