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
    int failCounter = 0;
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
        failCounter++;
        //replace 5 with variable containing track specific max consecutive fails
        //this has to be done here in order to preserve the actual combo, max scores
        if (failCounter >= 5)
        {
            SongManager songManager = FindObjectOfType<SongManager>();
            Debug.Log("done");
            if(songManager != null)
            {
                if(songManager.resultScreenShown == false)
                {
                    songManager.resultScreenShown = true;
                    songManager.FadeoutToResult();
                }
            }
        }
        comboScore -= 1;
        maxScore++;
        missSFX.Play();
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
    }

    public int getComboScore()
    {
        return comboScore;
    }
}
