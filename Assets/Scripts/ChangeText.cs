using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
	public TextMeshProUGUI textMeshPro;
	//public string testtext;

	public void SetNewText(int input)
	{
		textMeshPro.text = input.ToString();
	}
	
	public string getText()
	{
		return textMeshPro.text;
	}
}
