using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameSelection : MonoBehaviour
{
	public void PlayCompareFruits()
	{
		SceneManager.LoadScene("CompareFruits");
	}

	public void Play34Slap()
	{
		SceneManager.LoadScene("Game34Slap");
	}

	public void MenuArchie()
	{
		SceneManager.LoadScene("Archie");
	}

	public void MenuMain()
	{
		SceneManager.LoadScene("MainMenu");
	}

}
