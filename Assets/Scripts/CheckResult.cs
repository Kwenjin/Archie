using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResult : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    public int solved = 0;
    public GameObject spawner;
   
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

					if (string.Compare(spawner.GetComponent<RandomSpawner>().solution, hit.transform.name) == 0)
					{
						solved += 1;
                        Debug.Log(solved);
                        spawner.GetComponent<RandomSpawner>().spawnObjects();
					} else
					{
                        Debug.Log("Super, du hast " + solved + " Aufgaben richtig gelöst!");
                        solved = 0;
                        spawner.GetComponent<RandomSpawner>().spawnObjects();
                    }
				}
			}
		}
    }
}
