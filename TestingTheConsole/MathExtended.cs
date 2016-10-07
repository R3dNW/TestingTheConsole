namespace CustomExtentions
{
    using System;

    /// <summary>
    /// A collection of functions to extend the 'normal' System.Math class.
    /// </summary>
    public static class MathExtended
    {
        public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
            {
                return min;
            }
            else if (value.CompareTo(max) > 0)
            {
                return max;
            }
            else
            {
                return value;
            }
        }
    }
}