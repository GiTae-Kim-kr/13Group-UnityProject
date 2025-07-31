using System;
using Backend.Object;

namespace Backend.Utils.Extension
{
    public static class PlayerCharacterTypeExtension
    {
        public static string ToTag(this PlayerCharacterType type)
        {
            switch (type)
            {
                case PlayerCharacterType.Player01 :
                    return Tag.Player01;
                case PlayerCharacterType.Player02 :
                    return Tag.Player02;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}