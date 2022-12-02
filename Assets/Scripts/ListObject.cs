using Melanchall.DryWetMidi.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class ListObject
{
    public int id;
    public Sprite layoutSprite;
    public Sprite overlayFivelineSprite;
    public AudioClip musicClip;
    public MidiFile musicMidiFile;

    public ListObject()
    {

    }

    public ListObject(int Id, Sprite LayoutSprite, 
        Sprite OverlayFiveLineSprite, AudioClip MusicClip, 
        MidiFile MusicMidiFile)
    {
        id = Id;
        layoutSprite = LayoutSprite;
        overlayFivelineSprite = Resources.Load<Sprite>("");
        musicClip = MusicClip;
        musicMidiFile = MusicMidiFile;
    }
}


