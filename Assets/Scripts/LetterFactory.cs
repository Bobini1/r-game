using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterFactory : MonoBehaviour
{
    public GameObject letterPrefab;
    public DeleteLetterOrQuit deleteLetterOrQuit;

    public RhythmGame game;


    public void CreateLetter(int i)
    {
        game = DataBase.LetterList[i];
        GameObject letter = Instantiate(game.letterPrefab);
        Camera.main.gameObject.GetComponent<ConfigureRhythmGame>().Configure(i);
        deleteLetterOrQuit.letter = letter;
        foreach(var zoom in letter.GetComponentsInChildren<Zoom>())
        {
            zoom.cam = Camera.main;
        }
    }
}
