using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backend.Object
{
    [Flags]
    public enum ObjectIdentity //플레이어타입 다중 선택 가능
    {
        None = 0, //00
        Player01 = 1<<0, //01 
        Player02 = 1<<1, //10
        Block = 1<<2 //100
    }
}