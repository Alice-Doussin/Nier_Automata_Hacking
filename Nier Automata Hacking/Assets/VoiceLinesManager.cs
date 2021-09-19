using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLinesManager : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> VoiceLines;
    int index;
    [SerializeField]
    float lineCooldownMax;
    float lineCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if(lineCooldown<=0)
            {
                SayLine();
            }
        }

        lineCooldown -= Time.deltaTime;
    }

    void SayLine()
    {
        gameObject.GetComponent<AudioSource>().clip = VoiceLines[index];
        gameObject.GetComponent<AudioSource>().Play();
        lineCooldown = lineCooldownMax;
        index++;
    }
}
