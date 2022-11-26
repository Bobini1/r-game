using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    int comboScore;
    int maxScore;
    void Start()
    {
        comboScore = 0;
    }
    public void Hit()
    {
        comboScore += 1;
        maxScore++;
        hitSFX.Play();
    }
    public void Miss()
    {
        comboScore -= 1;
        maxScore++;
        missSFX.Play();
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
    }
}
