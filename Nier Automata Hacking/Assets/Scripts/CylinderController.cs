using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour
{
    [SerializeField]
    float shotCooldownMax;
    float shotCooldown;
    [SerializeField]
    GameObject PurpleShot;
    [SerializeField]
    GameObject Spawner1;
    [SerializeField]
    GameObject Spawner2;
    [SerializeField]
    GameObject Spawner3;
    [SerializeField]
    GameObject Spawner4;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float curYRot;
    [SerializeField]
    public int lives;
    [SerializeField]
    GameObject gameController;
    [SerializeField]
    AudioClip HitSound;
    [SerializeField]
    AudioClip ExplodeSound;
    [SerializeField]
    GameObject hitWhite;
    [SerializeField]
    float feedbackCooldownMax;
    float feedbackCooldown;
    float hitCooldown;
    [SerializeField]
    float hitCooldownMax;


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
                Instantiate(PurpleShot, Spawner1.GetComponent<Transform>().position, gameObject.GetComponent<Rigidbody>().rotation * Quaternion.Euler(new Vector3(0, -90, 0)));
                Instantiate(PurpleShot, Spawner2.GetComponent<Transform>().position, gameObject.GetComponent<Rigidbody>().rotation * Quaternion.Euler(new Vector3(0,90,0)));
                Instantiate(PurpleShot, Spawner3.GetComponent<Transform>().position, gameObject.GetComponent<Rigidbody>().rotation * Quaternion.Euler(new Vector3(0, 180, 0)));
                Instantiate(PurpleShot, Spawner4.GetComponent<Transform>().position, gameObject.GetComponent<Rigidbody>().rotation);
                shotCooldown = shotCooldownMax;
            }
            shotCooldown -= Time.deltaTime;
            curYRot += rotationSpeed * Time.deltaTime;
            gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, curYRot, 0)));

            if (lives <= 0)
            {
                gameObject.GetComponent<AudioSource>().clip = ExplodeSound;
                gameObject.GetComponent<AudioSource>().Play();
                Destroy(gameObject);
            }

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
                lives--;
                feedbackCooldown = feedbackCooldownMax;
                gameObject.GetComponent<AudioSource>().clip = HitSound;
                gameObject.GetComponent<AudioSource>().Play();
                hitWhite.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        
    }

    void GotHit()
    {
        if (hitCooldown <= 0)
        {
            lives--;
            hitCooldown = hitCooldownMax;
            feedbackCooldown = feedbackCooldownMax;
            gameObject.GetComponent<AudioSource>().clip = HitSound;
            gameObject.GetComponent<AudioSource>().Play();
            hitWhite.GetComponent<MeshRenderer>().enabled = true;

        }
    }
}
