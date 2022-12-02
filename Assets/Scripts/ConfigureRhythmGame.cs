using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureRhythmGame : MonoBehaviour
{
    public GameObject rhythmGame;
    public AudioSource audioSource;
    public Sprite layout;
    public Sprite noteProgressBar;
    public SongManager songManager;

    public RhythmGame dataBaseRelay = new RhythmGame();

    public void Awake()
    {
        rhythmGame.SetActive(false);
    }


    public void Configure()
    {

    }
}
