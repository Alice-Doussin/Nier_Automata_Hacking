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
    AudioClip buttonPressedSound;
    [SerializeField]
    AudioClip typingSound;
    [SerializeField]
    AudioClip levelBeginSound;
    [SerializeField]
    AudioClip popUpSound;
    public int level;
    bool hasTypingSoundPlayed;
    [SerializeField]
    GameObject door1;
    [SerializeField]
    GameObject door2;
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
                if(level==1)
                {
                    MenuAnimator.SetBool("TypingCode", true);
                }
                if(MenuAnimator.GetCurrentAnimatorStateInfo(0).IsName("Identity_popup"))
                {
                    MenuAnimator.SetBool("Lvl2Begin", true);
                    isInMenus = false;
                    isGamePlaying = true;
                    door1.SetActive(false);
                }
                if (MenuAnimator.GetCurrentAnimatorStateInfo(0).IsName("ProjetNierAutomata_popup"))
                {
                    MenuAnimator.SetBool("Lvl3Begin", true);
                    isInMenus = false;
                    isGamePlaying = true;
                    door2.SetActive(false);
                }
                gameObject.GetComponent<AudioSource>().clip = buttonPressedSound;
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
        if (level == 3)
        {
            MenuAnimator.SetBool("Lvl2Finished", true);
        }
        if (level == 4)
        {
            MenuAnimator.SetBool("Lvl3Finished", true);
        }
    }
    
    
}
