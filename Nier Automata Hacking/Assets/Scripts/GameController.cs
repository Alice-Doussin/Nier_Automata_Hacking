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
    [SerializeField]
    float timeUntilpopupSoundMax;
    float timeUntilPopupSound;
    bool startPopupSoundCountdown;
    // Start is called before the first frame update
    void Start()
    {
        isGamePlaying = false;
        isInMenus = true;
        level = 1;
        hasTypingSoundPlayed = false;
        timeUntilPopupSound = timeUntilpopupSoundMax;
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

            if (MenuAnimator.GetCurrentAnimatorStateInfo(0).IsName("FinishLevel") || MenuAnimator.GetCurrentAnimatorStateInfo(0).IsName("FinishLevel 2") || MenuAnimator.GetCurrentAnimatorStateInfo(0).IsName("FinishLevel 3"))
            {
                startPopupSoundCountdown = true;
                timeUntilPopupSound = timeUntilpopupSoundMax;
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

            if(startPopupSoundCountdown)
            {
                timeUntilPopupSound -= Time.deltaTime;
            }
            if(timeUntilPopupSound<=0)
            {
                if (MenuAnimator.GetCurrentAnimatorStateInfo(0).IsName("Identity_popup") || MenuAnimator.GetCurrentAnimatorStateInfo(0).IsName("ProjetNierAutomata_popup") || MenuAnimator.GetCurrentAnimatorStateInfo(0).IsName("Capacites_popup"))
                {
                    gameObject.GetComponent<AudioSource>().clip = popUpSound;
                    gameObject.GetComponent<AudioSource>().Play();
                    startPopupSoundCountdown = false;
                    timeUntilPopupSound = timeUntilpopupSoundMax;
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
