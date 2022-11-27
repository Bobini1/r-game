using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EscapeLetter : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent onEscape;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onEscape.Invoke();
        }
        // Escape when clicked dark background
        if  (GameObject.Find("LetterHolder").GetComponent<DeleteLetterOrQuit>().letter != null
            && Camera.main.GetComponent<Camera>().orthographicSize > 3.0f
            && (Input.mousePosition.x < 600f || Input.mousePosition.x > 1320f
            ||  Input.mousePosition.y < 15f || Input.mousePosition.y > 1065f)
            && Input.GetMouseButtonDown(0))
        {
            onEscape.Invoke();
        }
    }
}
