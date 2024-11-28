using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Methods : MonoBehaviour
{
    public static List<T> CreateList<T>(int capacity) => Enumerable.Repeat(default(T), capacity).ToList();

    public static void UpgradeCheck<T>(ref List<T> list, int lenght) where T : new()
    {
        try
        {
            if (list.Count == 0) list = CreateList<T>(lenght);
            while (list.Count < lenght) list.Add(new T());
        }
        catch
        {
            list = CreateList<T>(lenght);
        }
    }
}
