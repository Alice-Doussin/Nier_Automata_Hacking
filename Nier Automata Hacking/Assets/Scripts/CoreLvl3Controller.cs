using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreLvl3Controller : MonoBehaviour
{
    [SerializeField]
    float shotCooldownMax;
    float shotCooldown;
    [SerializeField]
    GameObject PurpleShot;
    [SerializeField]
    GameObject CoreSpawner1;
    [SerializeField]
    GameObject CoreSpawner2;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float curYRot;
    [SerializeField]
    public int lives;
    [SerializeField]
    GameObject gameController;
    [SerializeField]
    AudioClip CoreHitSound;
    [SerializeField]
    AudioClip CoreExplodeSound;
    public ParticleSystem Hit_particles;
    bool hasGoneToNextLvl;

    // Start is called before the first frame update
    void Start()
    {
        curYRot = gameObject.GetComponent<Rigidbody>().rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GetComponent<GameController>().isGamePlaying)
        {
            
            if (shotCooldown <= 0)
            {

                Instantiate(PurpleShot, CoreSpawner1.GetComponent<Transform>().position, gameObject.GetComponent<Rigidbody>().rotation);
                Instantiate(PurpleShot, CoreSpawner1.GetComponent<Transform>().position, gameObject.GetComponent<Rigidbody>().rotation * Quaternion.Euler(new Vector3(0, 180, 0)));

                shotCooldown = shotCooldownMax;
            }
            shotCooldown -= Time.deltaTime;
            
            curYRot += rotationSpeed * Time.deltaTime;
            gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, curYRot, 0)));

            if (lives <= 0)
            {
                gameObject.GetComponent<AudioSource>().clip = CoreExplodeSound;
                gameObject.GetComponent<AudioSource>().Play();
                gameController.GetComponent<GameController>().isGamePlaying = false;
                gameController.GetComponent<GameController>().isInMenus = true;
                if (hasGoneToNextLvl == false)
                {
                    gameController.GetComponent<GameController>().GoToNextLevel();
                    hasGoneToNextLvl = true;
                }
                Destroy(gameObject,gameObject.GetComponent<AudioSource>().clip.length-0.7f);
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (gameController.GetComponent<GameController>().isGamePlaying)
        {
            if (other.gameObject.tag == "PlayerShot")
            {
                lives--;
                gameObject.GetComponent<AudioSource>().clip = CoreHitSound;
                gameObject.GetComponent<AudioSource>().Play();
                Hit_particles.Play();
            }
        }
        
    }
}
