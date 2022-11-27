using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] scores;

    public PlayerData(Player player)
    {
        scores = new float[16];
        scores = player.scores;
    }
}
