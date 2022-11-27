using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Glow : MonoBehaviour
{

    public SpriteRenderer image;

    // Start is called before the first frame update
    void Start()
    {
        if (image == null)
        {
            image = GetComponent<SpriteRenderer>();
        }
        image.color = new Color32(255, 255, 255, 0); ;
    }

    public void DoGlow()
    {
        image.color = new Color32(255, 255, 255, 65);
        Invoke("StopGlow", 0.2f);
    }

    public void StopGlow()
    {
        image.color = Color.clear;
    }


}
