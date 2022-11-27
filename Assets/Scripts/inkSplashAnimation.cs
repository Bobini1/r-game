using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inkSplashAnimation : MonoBehaviour
{
    public void playOnce()
    {
        GetComponent<Animation>()["inkSplashAnimation2"].wrapMode = WrapMode.Once;
        GetComponent<Animation>().Play("inkSplashAnimation2");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
