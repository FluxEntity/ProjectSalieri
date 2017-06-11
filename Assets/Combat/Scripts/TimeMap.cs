using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMap {

    private float[] map;

    public TimeMap(float[,] input, float bpm) {
        float currentTime = 0;
        map = new float[input.Length];
        for(int i = 0; i < input.Length; i++)
        {
            map[i] = currentTime;
            currentTime = currentTime + 60 * (4f / input[i, 6]) / bpm;
        }
    }

    public float[] getMap()
    {
        return map;
    }
}
