using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData
{
	public string playerName;
	public int[] gamesActive;

	public playerData (Player player)
	{
		playerName = player.playerName;
	}

}
