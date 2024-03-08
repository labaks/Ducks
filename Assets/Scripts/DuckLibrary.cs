using System;
using UnityEngine;

public static class DuckLibrary
{
    public static String[] ducksNames = { "Ordinary Duck", "Blue Duck", "Golden Duck" };
    public static float[] duckRelativities = {
        100f,
        60f,
        15f
    };
    public static float[,] Duck_LVL_Prices = {
        /* 0     1     2      3       4        5       6        7        8          9        10   */
        { 0f,   50f,  85f,  144.5f, 245.6f,  417.6f, 709.9f,  1206.8f, 2051.7f,  3487.9f,  5929.4f }, // Ordinary Duck
        { 100f, 250f, 425f, 722.5f, 1228.3f, 2088f,  3549.6f, 6034.4f, 10258.5f, 17439.4f, 29647f }, // Blue Duck
        { 250f, 500f, 850f, 1445f,  2456f,   4176f,  7099f,   12068f,  20517f,   34879f,   59294f }  // Golden Duck
    };
    public static float[,] Duck_Prices = {
        /* 0   1     2     3     4     5     6     7     8     9    10*/
        { 1f, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2f }, // Ordinary Duck
        { 2f, 2.2f, 2.4f, 2.6f, 2.8f, 3f,   3.2f, 3.4f, 3.6f, 3.8f, 4f }, // Blue Duck
        { 5f, 5.3f, 5.6f, 5.9f, 6.2f, 6.5f, 6.8f, 7.1f, 7.4f, 7.7f, 8f }  // Golden Duck
    };
}