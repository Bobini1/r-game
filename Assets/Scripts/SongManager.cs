using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;

public class SongManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Lane[] lanes;
    public float songDelayInSeconds;
    public float songFadeoutInSeconds;
    public double marginOfError; // in seconds

    public int inputDelayInMilliseconds;
    
    

    public string fileLocation;
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;
    private bool showingResultScreen = false;
    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }
    
    public int GetSongNotes()
    {
        int numOfNotes = 0;
        foreach (var lane in lanes)
        {
            numOfNotes += lane.getLaneNotes();
        }
        return numOfNotes;
    }

    public int getScorePercent()
    {
        int playerScore = GetSongNotes();
        int maxScore = GetComponent<ScoreManager>().getComboScore();
        return (int)(playerScore / maxScore * 100.0F);
    }

    public bool IsFinished()
    {
        foreach (var lane in lanes)
        {
            if (!lane.IsFinished())
            {
                return false;
            }
        }
        return true;
    }

    public static MidiFile midiFile;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.streamingAssetsPath.StartsWith("http://") || Application.streamingAssetsPath.StartsWith("https://"))
        {
            StartCoroutine(ReadFromWebsite());
        }
        else
        {
            ReadFromFile();
        }
    }

    private IEnumerator ReadFromWebsite()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Application.streamingAssetsPath + "/" + fileLocation))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                byte[] results = www.downloadHandler.data;
                using (var stream = new MemoryStream(results))
                {
                    midiFile = MidiFile.Read(stream);
                    GetDataFromMidi();
                }
            }
        }
    }

    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }
    public void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);

        Invoke(nameof(StartSong), songDelayInSeconds);
    }
    public void StartSong()
    {
        audioSource.Play();
    }
    public double GetAudioSourceTime()
    {
        return (double)audioSource.timeSamples / audioSource.clip.frequency;
    }

    void Update()
    {
        if (!showingResultScreen && IsFinished())
        {
            showingResultScreen = true;
            Invoke(nameof(FadeoutToResult), songFadeoutInSeconds);
        }
    }

    private void FadeoutToResult()
    {
        int score = getScorePercent();
        GetComponent<SongResultFactory>().Create("Jew Chaos", score);
    }
}
