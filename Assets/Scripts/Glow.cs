using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Glow : MonoBehaviour
{

    public UnityEngine.UI.Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    public void DoGlow()
    {
        image.color = new Color32(255, 255, 225, 40);
        Invoke("StopGlow", 0.2f);
    }

    public void StopGlow()
    {
        image.color = Color.clear;
    }


}
