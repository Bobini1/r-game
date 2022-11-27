using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float[] scores = new float[16];
    private void Start()
    {
        scores[0] = 200.0f;
        scores[1] = 200.0f;
        scores[2] = 200.0f;
        scores[3] = 200.0f;
        scores[4] = 200.0f;
        scores[5] = 200.0f;
        scores[6] = 200.0f;
        scores[7] = 200.0f; 
        scores[8] = 200.0f;
        scores[9] = 200.0f;
        scores[10] = 200.0f;
        scores[11] = 200.0f;
        scores[12] = 200.0f;
        scores[13] = 200.0f;
        scores[14] = 200.0f;
        scores[15] = 200.0f;
    }

    public void SavePlayer()
    {
        SaveData.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveData.LoadPlayer();
        scores = data.scores;
    }
}
