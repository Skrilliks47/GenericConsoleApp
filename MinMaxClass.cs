using System;

namespace GenericConsoleApp
{
    public static class MinMaxClass
    {
        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) >= 0 ? a : b;
        }

        public static T Min<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) <= 0 ? a : b;
        }
    }
}