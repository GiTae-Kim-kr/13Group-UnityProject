using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ButtonGroup : MonoBehaviour
{
    [SerializeField] private float time = 3f;

    public UnityEvent onMove;
    public UnityEvent onReturned;

    public void Press()
    {
        Count++;
        if (Count > 0)
        {
            onMove.Invoke();
        }
    }

    public void Release()
    {
        Count--;
        if (Count <= 0)
        {
            onReturned.Invoke();
        }
    }

    public int Count { get; set; }
}