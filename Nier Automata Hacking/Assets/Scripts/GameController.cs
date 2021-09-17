using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isGamePlaying;
    public bool isInMenus;
    [SerializeField]
    Animator MenuAnimator;
    [SerializeField]
    AudioClip beginEnterPasswordSound;
    [SerializeField]
    AudioClip typingSound;
    [SerializeField]
    AudioClip levelBeginSound;
    [SerializeField]
    AudioClip popUpSound;
    public int level;
    bool hasTypingSoundPlayed;
    // Start is called before the first frame update
    void Start()
    {
        isGamePlaying = false;
        isInMenus = true;
        level = 1;
        hasTypingSoundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInMenus)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                MenuAnimator.SetBool("TypingCode", true);
                gameObject.GetComponent<AudioSource>().clip = beginEnterPasswordSound;
                gameObject.GetComponent<AudioSource>().Play();
            }
            if (MenuAnimator.GetCurrentAnimatorStateInfo(0).IsName("Title_validation"))
            {
                if(hasTypingSoundPlayed==false)
                {
                    gameObject.GetComponent<AudioSource>().clip = typingSound;
                    gameObject.GetComponent<AudioSource>().Play();
                    hasTypingSoundPlayed = true;
                }
                
            }

        }
        
        if (MenuAnimator.GetCurrentAnimatorStateInfo(0).IsName("BeginHackingText"))
        {
            isGamePlaying = true;
        }
    }

    public void GoToNextLevel()
    {
        level++;
        if(level==2)
        {
            MenuAnimator.SetBool("Lvl1Finished", true);
        }
    }
    
    
}
