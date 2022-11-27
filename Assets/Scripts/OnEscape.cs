using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEscape : MonoBehaviour
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
    }
}
