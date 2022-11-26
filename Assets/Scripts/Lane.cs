using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        songManager = GameObject.Find("SongManager").GetComponent<SongManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
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
    // Update is called once per frame
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
            }
        }
    }

    private bool ShouldSpawnNote()
    {
        return spawnIndex < timeStamps.Count && songManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - songManager.noteTime;
    }

    private void Hit()
    {
        scoreManager.Hit();
    }
    private void Miss()
    {
        scoreManager.Miss();
    }
}
