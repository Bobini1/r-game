using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject[] notePrefabs = new GameObject[8];
    public GameObject notePrefab;
    List<Note> notes = new();
    public List<double> timeStamps = new();
    public SongManager songManager;
    public ScoreManager scoreManager;
    int spawnIndex;
    int inputIndex;

    void Start()
    {
        songManager = GameObject.Find("SongManager").GetComponent<SongManager>();
        scoreManager = GameObject.Find("SongManager").GetComponent<ScoreManager>();
    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {      
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }
    void Update()
    {
        AddNewNotes();
        JudgeHits();
    }
    
    public bool IsFinished()
    {
        return inputIndex >= timeStamps.Count;
    }

    public int getLaneNotes()
    {
        return timeStamps.Count;
    }

    private void JudgeHits()
    {
        if (!IsFinished())
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = songManager.marginOfError;
            double audioTime = songManager.GetAudioSourceTime() - (songManager.inputDelayInMilliseconds / 1000.0);

            if (Input.GetKeyDown(input))
            {
                if (Math.Abs(audioTime - timeStamp) <= marginOfError)
                {
                    Hit();
                    print($"Hit on {inputIndex} note");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                    
                }
                else
                {
                    print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                    Miss();
                }

            }
            
            if (timeStamp + marginOfError <= audioTime)
            {
                Miss();
                print($"Missed {inputIndex} note");
                inputIndex++;
            }
        }
    }

    private void AddNewNotes()
    {
        if (!IsFinished())
        {
            if (ShouldSpawnNote())
            {
                System.Random rndNumber = new System.Random();
                notePrefab = notePrefabs[rndNumber.Next(0, 4)];
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float) timeStamps[spawnIndex];
                spawnIndex++;
                if(spawnIndex < 2)
                {
                    Destroy(notes[inputIndex].gameObject);
                }
            }
        }
        /*else   // get last time stamp
        {
            GameObject.Find("SongManager").GetComponent<ScoreManager>().maxTimeStamps.Add((float)timeStamps[spawnIndex-1]);
        }*/
    }

    private bool ShouldSpawnNote()
    {
        return spawnIndex < timeStamps.Count && songManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - songManager.noteTime;
    }

    private void Hit()
    {
        scoreManager.Hit();
        GameObject.Find("GlowEffect").GetComponent<Glow>().DoGlow();
    }
    private void Miss()
    {
        if(spawnIndex > 1)
        {
            scoreManager.Miss();
            GameObject.Find("GlowEffect").GetComponent<Glow>().DoGlowBad();
        }
    }
}
