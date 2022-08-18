using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawn34Slap : MonoBehaviour
{
    public int minNumber;
    public int maxNumber;
    public int beginSolCount;
    public char[] mathOperator;
    public int solution;
    public GameObject SolCard;
    public Collider2D[] colliders;
    public float radius = 2.0f;

    public TextMeshProUGUI taskText;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnObjects();
    }

    public void spawnObjects()
	{
        destroyObjects();
        SpawnTask();
        SpawnSolutions();
    }

    public void SpawnTask()
	{
        int selectOp = Random.Range(0, mathOperator.Length);
        int operand1 = 0;
        int operand2 = 0;

        switch (mathOperator[selectOp])
		{
            case '+': operand1 = Random.Range(minNumber+1, maxNumber - (minNumber+1));
                operand2 = Random.Range(minNumber+1, maxNumber - operand1);
                solution = operand1 + operand2;
                break;
            case '-': operand2 = Random.Range(minNumber+1, maxNumber-(minNumber+1));
                operand1 = Random.Range(operand2, maxNumber);
                solution = operand1 - operand2;
                break;
            case '*': Debug.Log("Not yet implemented");
                break;
            case '/': Debug.Log("Not yet implemented");
                break;
            default: Debug.Log("Somethings wrong here");
                break;
        }
        //Debug.Log(operand1);
        //Debug.Log(operand2);
        //Debug.Log(solution);
        taskText.text = operand1.ToString() + " " + mathOperator[selectOp].ToString() + " " + operand2.ToString() + " =";
	}

    public void SpawnSolutions()
	{
        int[] printSolutions = new int[beginSolCount];
        printSolutions[0] = solution;
        bool checkResults;
        int newResult = 0;

        for (int i = 1; i < printSolutions.Length; i++)
		{
            checkResults = false;
            while (!checkResults)
			{
                newResult = Random.Range(minNumber, maxNumber);
                checkResults = true;
                for (int a = 0; a<=i; a++)
				{
					if (newResult == printSolutions[a])
					{
                        checkResults = false;
					}
				}
                if (checkResults)
				{
                    break;
				}
            }
            printSolutions[i] = newResult;
		}

        foreach (int sol in printSolutions) {
            SpawnObjectAtRandom(SolCard, sol);
		}

	}

    void SpawnObjectAtRandom(GameObject solutionCard, int solText)
    {
        Vector3 randomPos = new Vector3(0, 0, 0);
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
        GameObject card = (GameObject)Instantiate(solutionCard, randomPos, Quaternion.identity);
        card.GetComponent<ChangeText>().SetNewText(solText);
    }

    bool PreventSpawnOverlap(Vector3 randomPos)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if (randomPos.x >= leftExtent && randomPos.x <= rightExtent)
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
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Solution"))
        {
            Destroy(o);
        }
    }

    public void increaseSolCount()
    {
        if (beginSolCount < 9)
        {
            beginSolCount++;
        }
    }
}
