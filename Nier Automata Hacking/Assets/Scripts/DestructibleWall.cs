using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    [SerializeField]
    int lives;
    [SerializeField]
    GameObject gameController;
    [SerializeField]
    AudioClip WallHitSound;
    [SerializeField]
    AudioClip WallExplodeSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            gameObject.GetComponent<AudioSource>().clip = WallExplodeSound;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject, gameObject.GetComponent<AudioSource>().clip.length - 0.7f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameController.GetComponent<GameController>().isGamePlaying)
        {
            if (other.gameObject.tag == "PlayerShot")
            {
                lives--;
                gameObject.GetComponent<AudioSource>().clip = WallHitSound;
                gameObject.GetComponent<AudioSource>().Play();
                
            }
        }

    }
}
