using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureRhythmGame : MonoBehaviour
{
    public GameObject rhythmGame;
    public AudioSource audioSource;
    public SpriteRenderer layout;
    public SpriteRenderer noteProgressBar;
    public SongManager songManager;
    public string midiLocation;

    public RhythmGame dataBaseRelay = new RhythmGame();

    public void Awake()
    {
        rhythmGame.SetActive(false);
    }


    public void Configure(int i)
    {
        dataBaseRelay = DataBase.LetterList[i];
        audioSource.clip = dataBaseRelay.musicClip;
        layout.sprite = dataBaseRelay.layoutSprite;
        //noteProgressBar = dataBaseRelay.noteProgressBar     enable once progress bars are int the catalogue!!! ~ dejwi
        songManager.fileLocation =

    }
}
