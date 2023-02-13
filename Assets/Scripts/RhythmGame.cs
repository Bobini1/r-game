using Melanchall.DryWetMidi.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class RhythmGame
{
    /// <summary>
    /// progress note summary;; there will be unique 16;; add to data base entries
    /// </summary>
    public int id;
    public string name;
    public Sprite layoutSprite;
    public Sprite overlayFivelineSprite;
    public AudioClip musicClip;
    public Sprite noteProgressBar;
    public GameObject letterPrefab;

    public RhythmGame()
    {

    }

    public RhythmGame(int Id, string Name)
    {
        id = Id;
        name = Name;
        layoutSprite = Resources.Load<Sprite>("Sprites/layouts/" + name);
        noteProgressBar = Resources.Load<Sprite>("Sprites/noteProgressBar/" + name);
        overlayFivelineSprite = Resources.Load<Sprite>("Sprites/5line/" + name);
        musicClip = Resources.Load<AudioClip>("Audio/" + name);
        letterPrefab = Resources.Load<GameObject>("Prefabs/" + name);
    }
}


