using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    int comboScore;
    void Start()
    {
        comboScore = 0;
    }
    public void Hit()
    {
        comboScore += 1;
        hitSFX.Play();
    }
    public void Miss()
    {
        comboScore = 0;
        missSFX.Play();    
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
    }
}
