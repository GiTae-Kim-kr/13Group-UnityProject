using System;

namespace Backend.Object
{
    [Flags]
    public enum ObjectIdentity
    {
        None = 0,
        Player01 = 1 << 0, 
        Player02 = 1 << 1,
        Block = 1 << 2
    }
}