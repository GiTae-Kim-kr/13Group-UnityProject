using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ButtonGroup : MonoBehaviour
{
    public UnityEvent onMove;
    public UnityEvent onReturned;

    public void Press() //버튼 눌렀을 때
    {
        Count++;
        if (Count > 0)
        {
            onMove.Invoke();
        }
    }

    public void Release() //버튼에서 나왔을 때
    {
        Count--;
        if (Count <= 0)
        {
            onReturned.Invoke();
        }
    }

    public int Count { get; set; }
}