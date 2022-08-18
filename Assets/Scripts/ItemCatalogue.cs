using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCatalogue : MonoBehaviour
{

    public GameObject player;
    public Button hatButton;
    public Button glassButton;

    // Start is called before the first frame update
    void Start()
    {
        if(player.GetComponent<Player>().hatsFound)
		{
            hatButton.enabled=true;
		}
        if (player.GetComponent<Player>().glassesFound)
        {
            glassButton.enabled=true;
        }
    }

}
