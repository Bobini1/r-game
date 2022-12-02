using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public static List<RhythmGame> LetterList = new List<RhythmGame>();


    private void Awake()
    {
        LetterList.Add(new RhythmGame(0, "Placeholder"));
        //¿yd
        LetterList.Add(new RhythmGame(1, "Jew_01"));
        LetterList.Add(new RhythmGame(2, "Jew_02"));
        LetterList.Add(new RhythmGame(3, "Jew_03"));
        LetterList.Add(new RhythmGame(4, "Jew_04"));
        //pola1
        LetterList.Add(new RhythmGame(5, "Pol_01"));
        LetterList.Add(new RhythmGame(6, "Pol_02"));
        LetterList.Add(new RhythmGame(7, "Pol_03"));
        LetterList.Add(new RhythmGame(8, "Pol_04"));
        //rosjanin
        LetterList.Add(new RhythmGame(9, "Rus_01"));
        LetterList.Add(new RhythmGame(10, "Rus_02"));
        LetterList.Add(new RhythmGame(11, "Rus_03"));
        LetterList.Add(new RhythmGame(12, "Rus_04"));
        //niemiec
        LetterList.Add(new RhythmGame(13, "Ger_01"));
        LetterList.Add(new RhythmGame(14, "Ger_02"));
        LetterList.Add(new RhythmGame(15, "Ger_03"));
        LetterList.Add(new RhythmGame(16, "Ger_04"));

    }
}
