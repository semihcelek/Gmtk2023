using System;

namespace SemihCelek.Gmtk2023.Utility
{
    public static class EnumHelper
    {
        public static T AddFlag<T>(this Enum enumaration, T value)
        {
            return (T)(object)((int)(object)enumaration | (int)(object)value);
        }

        public static T RemoveFlag<T>(this Enum enumaration, T value)
        {
            return (T)(object)((int)(object)enumaration & ~(int)(object)value);
        }
    }
}