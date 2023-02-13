using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneStateful : MonoBehaviour
{
    //public string sceneName;
    public RhythmGame game;
    public int songID;
    private void Awake()
    {


    }
    public void LoadScene()
    {
        game = DataBase.LetterList[songID];

        Camera.main.GetComponent<ConfigureRhythmGame>().Configure(songID);

        //SceneManager.LoadScene(sceneName);
    }
}