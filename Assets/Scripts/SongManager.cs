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
    public new string name;

    public int inputDelayInMilliseconds;


    public int songID;
    public RhythmGame game;


    public string fileLocation;
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;
    private bool showingResultScreen = false;

    public bool resultScreenShown = false;

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

    public float getScorePercent()
    {
        float maxScore = GetSongNotes();
        float playerScore = GetComponent<ScoreManager>().getComboScore();
        return (float)Math.Round(playerScore / maxScore * 100.0f, 2);
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

    [Obsolete]
    void Start()
    {       
        ReadFromFile();
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

    public void FadeoutToResult()
    {
        float score = getScorePercent();
        GetComponent<SongResultFactory>().Create(name, score);
        audioSource.volume = 0;
    }
}
