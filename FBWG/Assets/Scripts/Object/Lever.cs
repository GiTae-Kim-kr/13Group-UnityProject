using System;
using System.Collections;
using System.Collections.Generic;
using Backend.Object;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Lever : CollisionEnteredDetection
{
    private int count = 0;
    public UnityEvent onMove;
    public UnityEvent onReturned;
    public bool leverStat = false;
    [SerializeField] private SpriteRenderer _thisImg; //현재 이미지(레버off 이미지)
    [SerializeField] private Sprite leverSpriteOff;
    [SerializeField] private Sprite leverSpriteOn;

    public void Contact()
    {
        Debug.Log("레버 접촉 상태");
        leverStat = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("레버 접촉 상태 아님");
        leverStat = false;
    }

    public void Interaction(){
        if (Input.GetKeyDown(KeyCode.Space) && leverStat) //레버에 닿아있을 때 플레이어가 스페이스 누르면
        {
            count++;
            if (count % 2 == 1) //레버 on
            {
                Debug.Log("레버on");
                _thisImg.sprite = leverSpriteOn;
                onMove.Invoke();
            }

            if (count % 2 == 0) //레버 off
            {
                Debug.Log("레버off");
                _thisImg.sprite = leverSpriteOff;
                onReturned.Invoke();
            }
        }
    }

    
    void Start()
    {
        this._thisImg = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Interaction();
    }
}
