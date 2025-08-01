using System;
using Backend.Object;

namespace Backend.Utils.Extension
{
    public static class PlayerCharacterTypeExtension //확장 메서드
    {
        public static string ToTag(this ObjectIdentity type)
        {
            switch (type)
            {
                case ObjectIdentity.Player01 :
                    return Tag.Player01;
                case ObjectIdentity.Player02 :
                    return Tag.Player02;
                default:
                    return string.Empty;
            }
        }
    }
}