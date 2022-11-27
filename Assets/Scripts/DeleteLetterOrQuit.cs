using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLetterOrQuit : MonoBehaviour
{
    public GameObject letter;

    private float initialCameraSize;

    private Vector3 initialCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        var main = Camera.main;
        initialCameraSize = main.orthographicSize;
        initialCameraPosition = main.transform.position;
    }
    public void Invoke()
    {
        if (letter != null)
        {
            Destroy(letter);
            if (Camera.main != null)
            {
                var main = Camera.main;
                main.orthographicSize = initialCameraSize;
                main.transform.position = initialCameraPosition;
            }
        }
        else
        {
            Application.Quit();
        }
    }
}
