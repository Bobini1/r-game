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
    public List<float> maxTimeStamps = new();

    //mark me for every song!!!
    public float speedAdjuster;
    public AudioSource audioSource;


    public GameObject progressBar;
    //float progressBarValue;
    float progressBarMaxValue;

    SongManager songManager;
    private void Awake()
    {
        songManager = FindObjectOfType<SongManager>();
    }
    void Start()
    {

        comboScore = 0;
        //progressBarValue = 0;
        if(songManager != null)
        {
            progressBarMaxValue = songManager.GetSongNotes();
        }
        Debug.Log(progressBarMaxValue);
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
        if (failCounter >= 200)
        {
            
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
        //set me

        //float speed = GameObject.Find("SongManager").GetComponent<SongManager>().GetSongNotes() / MaxTimeStamp();
        //audioSource.GetComponent<AudioClip>().length();
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
