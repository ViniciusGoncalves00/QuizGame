using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utilities
{
    public static List<T> RandomizeList<T>(List<T> tempList)
    {
        var initialSize = tempList.Count;

        var randomizedList = new List<T>(initialSize);

        for (int i = 0; i < initialSize; i++)
        {
            var randomIndex = Random.Range(0, tempList.Count);
            var item = tempList[randomIndex];
            tempList.RemoveAt(randomIndex);
            randomizedList.Add(item);
        }

        return randomizedList;
    }
}