using UnityEngine;
using System.Collections.Generic;

public static class Math
{
    public static float Remap(this float f, float low1, float high1, float low2, float high2)
    {
        return low2 + (f - low1) * (high2 - low2) / (high1 - low1);
    }

    public static float ClampAngle(this float f, float min, float max)
    {
        f -= 180;
        while(f < 0)
            f += 360;

        f = Mathf.Repeat(f, 360);
        return Mathf.Clamp(f - 180, min, max) + 360;
    }
}

public static class Array
{
    public static int WrapIndex(int index, int arrayLength)
    {
        return ((index % arrayLength) + arrayLength) % arrayLength;
    }

    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while(n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    static void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        for(int i = 0; i < n; i++)
        {
            int r = i + rng.Next(n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
}