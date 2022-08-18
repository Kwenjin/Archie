using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData
{
	public string playerName;
	public bool hatsFound;
	public bool glassesFound;
	public int playerHat;
	public int playerGlasses;

	public playerData (Player player)
	{
		playerName = player.playerName;
		playerHat = player.hat;
		playerGlasses = player.glasses;
		hatsFound = player.hatsFound;
		glassesFound = player.glassesFound;

	}
}
