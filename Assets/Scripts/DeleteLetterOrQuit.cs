using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLetterOrQuit : MonoBehaviour
{
    public GameObject letter;
    // Start is called before the first frame update
    public void Invoke()
    {
        if (letter != null)
        {
            Destroy(letter);
        }
        else
        {
            Application.Quit();
        }
    }
}
