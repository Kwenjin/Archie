using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject apple;
    public GameObject strawberry;
    public Collider2D[] colliders;
    public float radius=2.0f;
    public int max = 10;
    public string solution;

    // Start is called before the first frame update
    void Start()
    {
        spawnObjects();
    }

    public void spawnObjects()
	{
        int obj1 = Random.Range(1, max + 1);
        int obj2 = Random.Range(1, max + 1);

        //define solution
        if (obj1 > obj2)
        {
            solution = "apple";
        }
        else if (obj1 < obj2)
		{
            solution = "strawberry";
		}
		else
		{
            solution = "equal";
		}

        destroyObjects();
        // spawn Objects;
        for (int i = 0; i < obj1; i++)
        {
            SpawnObjectAtRandom(apple);
        }
        for (int i = 0; i < obj2; i++)
        {
            SpawnObjectAtRandom(strawberry);
        }
    }

    void SpawnObjectAtRandom(GameObject fruit)
	{
        Vector3 randomPos = new Vector3(0,0,0);
        bool canSpawnHere = false;

        while (!canSpawnHere)
        {
            float spawnPosX = Random.Range(-9.0f, 9.0f);
            float spawnPosY = Random.Range(-1.5f, 4.0f);
            randomPos = new Vector3(spawnPosX, spawnPosY, 0);
            canSpawnHere = PreventSpawnOverlap(randomPos);

			if (canSpawnHere)
			{
                break;
			}
        }
        Instantiate(fruit, randomPos, Quaternion.identity);
	}

    bool PreventSpawnOverlap(Vector3 randomPos)
	{
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i=0; i< colliders.Length; i++)
		{
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if(randomPos.x >= leftExtent && randomPos.x <= rightExtent)
			{
                if (randomPos.y >= lowerExtent && randomPos.y <= upperExtent)
				{
                    return false;
				}
			}

		}
        return true;
    }

    private void destroyObjects()
	{
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Respawn"))
		{
            Destroy(o);
		}
	}
}
