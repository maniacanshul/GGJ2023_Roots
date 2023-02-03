using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[CreateAssetMenu]
public class ScriptableObjectNumbersGenerator : ScriptableObject
{
    public int minNumber;
    public int maxNumber;

    public List<int> perfectSquares;
    public List<int> perfectCubes;
    public List<int> remainingNumbers;

    [ContextMenu("Generate series")]
    public void GenerateNewNumbers()
    {
        perfectCubes.Clear();
        perfectSquares.Clear();
        remainingNumbers.Clear();

        for (int i = minNumber; i < maxNumber; i++)
        {
            bool wasAValidNum = false;
            for (int j = 1; j < i; j++)
            {
                if (j * j == i)
                {
                    wasAValidNum = true;
                    perfectSquares.Add(i);
                }

                if (j * j * j == i)
                {
                    wasAValidNum = true;
                    perfectCubes.Add(i);
                }
            }

            if (!wasAValidNum)
            {
                remainingNumbers.Add(i);
            }
        }
    }

    public bool IsNumberAPerfectSquare(int number)
    {
        return perfectSquares.Contains(number);
    }

    public bool IsNumberAPerfectCube(int number)
    {
        return perfectCubes.Contains(number);
    }

    public bool IsNumberANormalNumber(int number)
    {
        if (!IsNumberAPerfectSquare(number) && !IsNumberAPerfectCube(number))
        {
            return true;
        }
        return false;
    }
}
