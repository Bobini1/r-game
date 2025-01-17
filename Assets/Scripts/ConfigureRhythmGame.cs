using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureRhythmGame : MonoBehaviour
{
    public GameObject rhythmGame;
    public GameObject navigationObject;
    public AudioSource audioSource;
    public SpriteRenderer layout;
    public SpriteRenderer noteProgressBar;
    public SongManager songManager;
    public RhythmGame dataBaseRelay = new RhythmGame();

    public void Awake()
    {
        rhythmGame.SetActive(false);
        navigationObject.SetActive(true);
    }

    public void Configure(int i)
    { 
        dataBaseRelay = DataBase.LetterList[i];
        audioSource.clip = dataBaseRelay.musicClip;
        layout.sprite = dataBaseRelay.layoutSprite;

        rhythmGame.SetActive(true);
        navigationObject.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("PreLoadList"));
        //noteProgressBar = dataBaseRelay.noteProgressBar     enable once progress bars are in the catalogue!!! ~ dejwi
        songManager.fileLocation = dataBaseRelay.name + ".mid";
    }
}
