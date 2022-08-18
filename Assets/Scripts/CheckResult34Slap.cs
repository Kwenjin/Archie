using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckResult34Slap : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public int solved = 0;
    public GameObject spawner;
    public GameObject endScreen;
    public GameObject player;
    public GameObject itemText;
    public TextMeshProUGUI solvedText;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Solution")
                {

                    if (string.Compare(spawner.GetComponent<Spawn34Slap>().solution.ToString(), hit.transform.GetComponent<ChangeText>().getText()) == 0)
                    {
                        solved += 1;
                        Debug.Log(solved);
                        spawner.GetComponent<Spawn34Slap>().spawnObjects();
						if (solved % 5 == 0)
						{
                            spawner.GetComponent<Spawn34Slap>().increaseSolCount();
                        }

                    }
                    else
                    {
                        bool Item = newItem();
                        if (Item)
						{
                            itemText.SetActive(true);
                            player.GetComponent<Player>().hatsFound = true;
                            player.GetComponent<Player>().SavePlayer();
						}
                        solvedText.text = "Super, du hast " + solved + " Aufgaben richtig gelöst!";
                        endScreen.SetActive(true);

                    }
                }
            }
        }
    }

    private bool newItem()
	{
        bool newItemFound = true;
        if (solved * Random.Range(1,10) > 20)
		{
            if(player.GetComponent<Player>().hatsFound == true)
			{
                newItemFound = false;
			}
		} else { 
            newItemFound = false;
        }
        return newItemFound;
	}



    public void Restart()
    {
        endScreen.SetActive(false);
        itemText.SetActive(false);
        solved = 0;
        spawner.GetComponent<Spawn34Slap>().beginSolCount = 4;
        spawner.GetComponent<Spawn34Slap>().spawnObjects();
    }
}
