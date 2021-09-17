using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float shotCooldownMax;
    float shotCooldown;
    [SerializeField]
    GameObject playerShot;
    [SerializeField]
    GameObject shotSpawner;
    public int lives;
    [SerializeField]
    GameObject leftPart;
    [SerializeField]
    GameObject rightPart;
    [SerializeField]
    GameObject frontPart;
    [SerializeField]
    float hitCooldownMax;
    float hitCooldown;
    [SerializeField]
    GameObject gameController;
    [SerializeField]
    AudioClip PlayerHitSound;
    [SerializeField]
    AudioClip PlayerDeathSound;
    void Start()
    {
        shotCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GetComponent<GameController>().isGamePlaying)
        {
            if (Input.GetKey("up") || Input.GetAxis("Vertical") > 0)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey("down") || Input.GetAxis("Vertical") < 0)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey("right") || Input.GetAxis("Horizontal") > 0)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey("left") || Input.GetAxis("Horizontal") < 0)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetAxis("Mouse X") > 0.1 || Input.GetAxis("Mouse X") < -0.1 || Input.GetAxis("Mouse Y") > 0.1 || Input.GetAxis("Mouse Y") < -0.1)
            {
                gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.Lerp(gameObject.GetComponent<Rigidbody>().rotation, Quaternion.Euler(new Vector3(0, Mathf.Atan2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * 180 / Mathf.PI + 90, 0)), Time.deltaTime * rotationSpeed));

            }

            if (Input.GetAxis("Fire1") > 0.1 && shotCooldown <= 0)
            {
                Instantiate(playerShot, shotSpawner.GetComponent<Transform>().position, gameObject.GetComponent<Rigidbody>().rotation);
                shotCooldown = shotCooldownMax;
            }

            shotCooldown -= Time.deltaTime;
            hitCooldown -= Time.deltaTime;

            if (lives <= 2)
            {
                Destroy(leftPart);
            }
            if (lives <= 1)
            {
                Destroy(rightPart);
            }
            if (lives <= 0)
            {
                Destroy(frontPart);

            }
        }
       
    }

    public void GotHit()
    {
        if (hitCooldown <= 0)
        {
            lives--;
            hitCooldown = hitCooldownMax;
            if(lives<=0)
            {
                gameObject.GetComponent<AudioSource>().clip = PlayerDeathSound;
                gameObject.GetComponent<AudioSource>().Play();
            }
            else
            {
                gameObject.GetComponent<AudioSource>().clip = PlayerHitSound;
                gameObject.GetComponent<AudioSource>().Play();
            }
            
        }
        
    }
}
