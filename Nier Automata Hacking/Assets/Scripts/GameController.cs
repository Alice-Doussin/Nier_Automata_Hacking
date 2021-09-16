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
    GameObject TitleScreen;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        isGamePlaying = false;
        isInMenus = true;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInMenus)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                MenuAnimator.SetBool("TypingCode", true);
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
