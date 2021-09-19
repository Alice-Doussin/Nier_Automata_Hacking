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
    bool isDestroyed;
    float hitCooldown;
    [SerializeField]
    float hitCooldownMax;
    [SerializeField]
    GameObject hitWhite;
    [SerializeField]
    float feedbackCooldownMax;
    float feedbackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        isDestroyed = false;
        hitCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDestroyed)
        {
            if (lives <= 0)
            {
                /*gameObject.GetComponent<AudioSource>().clip = WallExplodeSound;
                gameObject.GetComponent<AudioSource>().Play();*/
                Destroy(gameObject);
                isDestroyed = true;
            }

            hitCooldown -= Time.deltaTime;
            feedbackCooldown -= Time.deltaTime;

            if (feedbackCooldown <= 0)
            {
                hitWhite.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameController.GetComponent<GameController>().isGamePlaying)
        {
            if (other.gameObject.tag == "PlayerShot")
            {
                GotHit();
                
                
            }
        }

    }

    public void GotHit()
    {

        if (hitCooldown <= 0)
        {
            lives--;
            hitCooldown = hitCooldownMax;
            feedbackCooldown = feedbackCooldownMax;
            gameObject.GetComponent<AudioSource>().clip = WallHitSound;
            gameObject.GetComponent<AudioSource>().Play();
            hitWhite.GetComponent<MeshRenderer>().enabled = true;

        }

    }
}
