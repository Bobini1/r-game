using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterFactory : MonoBehaviour
{
    public GameObject letterPrefab;
    GameObject CreateLetter(string topText, string bottomText, string songPath)
    {
        GameObject letter = Instantiate(letterPrefab);
        letter.transform.Find("LetterBeginning").GetComponent<TextMeshProUGUI>().text = topText;
        letter.transform.Find("BottomText").GetComponent<TextMeshProUGUI>().text = bottomText;
        letter.transform.Find("StartSong").GetComponent<ChangeSceneStateful>().sceneName = songPath;
        return letter;
    }
}
