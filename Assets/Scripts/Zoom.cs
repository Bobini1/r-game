using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Zoom : MonoBehaviour
{
    public Camera cam;
    public float speed = 10;
    private float initialZoom;
    private float initialY;
    public float maxZoom;
    private float targetZoom;
    public float endY;
    private float targetY;
    private float currentY;
    private float currentZoom;
    private float stepsForFullZoom;
    private bool _zooming;
    public UnityEvent zoomComplete;
    public bool Zooming {
        get { return _zooming; }
        private set
        {
            if (value)
            {
                targetZoom = maxZoom;
                targetY = endY;
            }
            else
            {
                targetZoom = initialZoom;
                targetY = initialY;
            }
            _zooming = value;
        }
}
    

    void Start()
    {
        var orthographicSize = cam.orthographicSize;
        initialY = cam.transform.position.y;
        initialZoom = orthographicSize;
        currentZoom = initialZoom;
        Zooming = false;
        cam = Camera.main;

        stepsForFullZoom = Mathf.Abs(initialY - endY) / Mathf.Abs(initialZoom - maxZoom);
    }
    void Update()
    {
        UpdateZoom();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        currentY = Mathf.MoveTowards(currentY, targetY, speed * Time.deltaTime * stepsForFullZoom);
        if (Mathf.Abs(currentY - targetY) > 0.0001f)
        {
            var position = cam.transform.position;
            position = new Vector3(position.x, currentY, position.z);
            cam.transform.position = position;
        }
    }

    private void UpdateZoom()
    {
        float newSize = Mathf.MoveTowards(currentZoom, targetZoom, speed * Time.deltaTime);
        if (Math.Abs(newSize - currentZoom) > 0.01)
        {
            cam.orthographicSize = newSize;
            currentZoom = newSize;
        }
        if (Math.Abs(currentZoom - maxZoom) < 0.01)
        {
            zoomComplete.Invoke();
        }
    }

    public void FlipZooming()
    {
        Zooming = !Zooming;
    }
}
