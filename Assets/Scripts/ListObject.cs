using Melanchall.DryWetMidi.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class ListObject
{
    /// <summary>
    /// progress note summary;; there will be unique 16;; add to data base entries
    /// </summary>
    public int id;
    public string name;
    public Sprite layoutSprite;
    public Sprite overlayFivelineSprite;
    public AudioClip musicClip;
    public MidiFile musicMidiFile;

    public ListObject()
    {

    }

    public ListObject(int Id, string name)
    {
        id = Id;
        layoutSprite = Resources.Load<Sprite>("Sprites/layouts/" + name);
        overlayFivelineSprite = Resources.Load<Sprite>("Sprites/5line/" + name);
        musicClip = Resources.Load<AudioClip>("Audio/" + name);
        musicMidiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + id);
    }
}


