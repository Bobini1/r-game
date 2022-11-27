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
        //float speed = 1f;
        float speed = (progressBarMaxValue / 360f)*1.2f; //Check whether it works for other tracks!!!!
        //float speed = GameObject.Find("SongManager").GetComponent<SongManager>().GetSongNotes() / MaxTimeStamp();
        
        //max X -18.5 - Final X 0
        if(progressBar.transform.position.x <= 0)
        {
            progressBar.transform.position += new Vector3(1, 0) * Time.deltaTime * speed;
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
