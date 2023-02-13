using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro comboPoints;
    int comboScore;
    int maxScore; // to implement
    int combo;
    int failCounter = 0;
    public int maxFails = 200;
    public List<float> maxTimeStamps = new();


    public GameObject progressBar;
    float progressBarMaxValue;

    public float speedAdjuster;
    public AudioSource audioSource;

    SongManager songManager;
    private void Awake()
    {
        songManager = FindObjectOfType<SongManager>();
    }
    void Start()
    {
        combo = 0;
        comboScore = 0;
        if(songManager != null)
        {
            progressBarMaxValue = songManager.GetSongNotes();
        }
        Debug.Log(progressBarMaxValue);
    }
    public void Hit()
    {
        comboScore += 1;
        combo++;
        maxScore++;
        hitSFX.Play();
    }
    public void Miss()
    {
        failCounter++;
        //replace 5 with variable containing track specific max consecutive fails
        //this has to be done here in order to preserve the actual combo, max scores
        if (failCounter >= maxFails)
        {            
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
        combo = 0;
        maxScore++;
        missSFX.Play();
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
        comboPoints.text = ("+" + combo.ToString());
        //set me

        //max X -17.8 - Final X 0
        float Xprop = (17.8f / audioSource.clip.length);
        speedAdjuster = Mathf.Abs(Xprop);
        //float speed = (progressBarMaxValue / 360f) * speedAdjuster; //Check whether it works for other tracks!!!!

        if (progressBar.transform.position.x <= 0)
        {
            progressBar.transform.position += new Vector3(1, 0) * Time.deltaTime * speedAdjuster;
        }
    }

    public int getComboScore()
    {
        return comboScore;
    }

    public float MaxTimeStamp()
    {
        float maxStamp = 0f;
        foreach (float stamp in maxTimeStamps)
        {
            maxStamp = System.Math.Max(maxStamp, stamp);
        }
        return maxStamp;
    }
}
