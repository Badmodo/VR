using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    public List<int> myList;

    void Start()
    {
        ListSortExtensions.LinierSearch<int>(myList, 32);
    }
}

public static class ListSortExtensions
{
    public static int LinierSearch<T>(this List<T> _list, T _target) where T:IComparable
    {
        for(int x = 0; x < _list.Count; x++)
        {
            if(_list[0].CompareTo(_target) == 0)
            {
                return x;
            }    
        }
        return -1;
    }
}

