using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterFactory : MonoBehaviour
{
    public GameObject letterPrefab;
    public GameObject mountingPoint;
    public DeleteLetterOrQuit deleteLetterOrQuit;

    void Start()
    {
        
    }

    public void CreateLetter()
    {
        GameObject letter = Instantiate(letterPrefab);
        deleteLetterOrQuit.letter = letter;
        foreach(var zoom in letter.GetComponentsInChildren<Zoom>())
        {
            zoom.cam = Camera.main;
        }
    }
}
