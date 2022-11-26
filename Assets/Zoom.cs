using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private Camera cam;
    public float speed = 30;
    private float initialZoom;
    public float maxZoom;
    private float targetZoom;
    private bool _zooming;
    public bool Zooming {
        get { return _zooming; }
        private set
        {
            if (value)
            {
                targetZoom = maxZoom;
            }
            else
            {
                targetZoom = initialZoom;
            }
            _zooming = value;
        }
}
    

    void Start()
    {
        cam = GetComponent<Camera>();
        var orthographicSize = cam.orthographicSize;
        initialZoom = orthographicSize;
        Zooming = false;
    }
    void Update()
    {
        float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, speed * Time.deltaTime);
        cam.orthographicSize = newSize;
    }
    
    public void FlipZooming()
    {
        Zooming = !Zooming;
    }
}
