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

    public int GetPerfectSquare(int max) {
        List<int> squares = new List<int>();
        for (int i = 0; i < perfectSquares.Count; i++)
        {
            if (perfectSquares[i] > max) break;

            squares.Add(perfectSquares[i]);
        }
        
        return squares[Random.Range(0, squares.Count)];
    }

    public int GetPerfectCube(int max) {
        List<int> cubes = new List<int>();
        for (int i = 0; i < perfectCubes.Count; i++)
        {
            if (perfectCubes[i] > max) break;
            cubes.Add(perfectCubes[i]);
        }
        
        return cubes[Random.Range(0, cubes.Count)];
    }

    public int GetNormalNumber(int max) {
        List<int> n = new List<int>();
        for (int i = 0; i < remainingNumbers.Count; i++)
        {
            if (remainingNumbers[i] > max) break;
            n.Add(remainingNumbers[i]);
        }
        
        return n[Random.Range(0, n.Count)];
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
