using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;
    private SongManager songManager;
    void Start()
    {
        songManager = GameObject.Find("SongManager").GetComponent<SongManager>();
        timeInstantiated = songManager.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = songManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (songManager.noteTime * 2));

        
        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.up * songManager.noteSpawnY, Vector3.up * songManager.noteDespawnY, t); 
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
