using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreMetric
{
    private int hits;
    private int total;
    private float hitRate;

    public ScoreMetric()
    {
        hits = 0;
        total = 0;
        hitRate = 0;
    }

    public ScoreMetric(int x, int y)
    {
        hits = x;
        total = y;
        calHitRate();
    }

    public void setHits(int n)
    {
        hits = n;
    }

    public void setTotal(int n)
    {
        total = n;
    }

    public void calHitRate()
    {
        hitRate = ((float)hits / (float)total) * 100;
    }

    public int getHits()
    {
        return hits;
    }

    public int getTotal()
    {
        return total;
    }

    public float getHitRate()
    {
        return hitRate;
    }
}
