using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;

public class SimpleCameraZoom : MonoBehaviour
{
    public float cameraSizeInitial;
    public float cameraSizeFinal;
    public float speed;
    public bool zoomCondition= false;

    void Start()
    {
        Camera.main.orthographicSize = 5;
        zoomCondition = false;
    }

    public void StartZoom()
    {
        Debug.Log("started zoom");
        //Camera.main.orthographicSize -= 4f;
        zoomCondition = true;
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomCondition && Camera.main.orthographicSize >= 0.3)
        {
            Camera.main.orthographicSize -= 0.3f * Time.deltaTime * speed;
            speed += 0.25f;
        }
        else if(zoomCondition == true)
        {
            gameObject.GetComponent<ChangeSceneStateful>().LoadScene();
        }
    }
}
