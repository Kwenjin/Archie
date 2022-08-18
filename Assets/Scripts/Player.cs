using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public string playerName;
	public bool hatsFound; 
	public bool glassesFound;
	public int hat;
	public int glasses;
	public GameObject hatObject;
	public GameObject glassesObject;

	void Start()
	{
		LoadPlayer();
		visualize();
	}

	public void SavePlayer()
	{
		SaveSystem.SavePlayer(this);
	}

	public void LoadPlayer()
	{
		playerData data = SaveSystem.LoadPlayer();

		playerName = data.playerName;
		hat = data.playerHat;
		glasses = data.playerGlasses;
		hatsFound = data.hatsFound;
		glassesFound = data.glassesFound;
	}

	public void setHat(int ID)
	{
		hat = ID;
	}

	public void setGlasses(int ID)
	{
		glasses = ID;
	}

	private void visualize()
	{
		if(hat == 1)
		{
			hatObject.SetActive(true);
		}
		if (glasses == 1)
		{
			glassesObject.SetActive(true);
		}
	}

}
