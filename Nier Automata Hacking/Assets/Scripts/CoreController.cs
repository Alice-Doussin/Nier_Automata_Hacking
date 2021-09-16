using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    [SerializeField]
    float shotCooldownMax;
    float shotCooldown;
    [SerializeField]
    GameObject OrangeShot;
    [SerializeField]
    GameObject PurpleShot;
    [SerializeField]
    GameObject CoreSpawner;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float curYRot;
    [SerializeField]
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        curYRot = gameObject.GetComponent<Rigidbody>().rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(shotCooldown<=0)
        {
            Instantiate(OrangeShot, CoreSpawner.GetComponent<Transform>().position, gameObject.GetComponent<Rigidbody>().rotation);
            shotCooldown = shotCooldownMax;
        }
        shotCooldown -= Time.deltaTime;
        curYRot += rotationSpeed * Time.deltaTime;
        gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, curYRot, 0)));

        if(lives<=0)
        {
            Destroy(gameObject);
        }
        
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerShot")
        {
            lives--;
        }
    }
}
