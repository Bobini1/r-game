using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public static List<ListObject> LetterList = new List<ListObject>();


    private void Awake()
    {
        LetterList.Add(new ListObject(0, "Placeholder"));
        //¿yd
        LetterList.Add(new ListObject(1, "Jew_01"));
        LetterList.Add(new ListObject(2, "Jew_02"));
        LetterList.Add(new ListObject(3, "Jew_03"));
        LetterList.Add(new ListObject(4, "Jew_04"));
        //pola1
        LetterList.Add(new ListObject(5, "Pol_01"));
        LetterList.Add(new ListObject(6, "Pol_02"));
        LetterList.Add(new ListObject(7, "Pol_03"));
        LetterList.Add(new ListObject(8, "Pol_04"));
        //rosjanin
        LetterList.Add(new ListObject(9, "Rus_01"));
        LetterList.Add(new ListObject(10, "Rus_02"));
        LetterList.Add(new ListObject(11, "Rus_03"));
        LetterList.Add(new ListObject(12, "Rus_04"));
        //niemiec
        LetterList.Add(new ListObject(13, "Ger_01"));
        LetterList.Add(new ListObject(14, "Ger_02"));
        LetterList.Add(new ListObject(15, "Ger_03"));
        LetterList.Add(new ListObject(16, "Ger_04"));

    }
}
