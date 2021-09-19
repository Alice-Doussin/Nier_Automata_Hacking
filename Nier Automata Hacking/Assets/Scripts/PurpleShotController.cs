using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleShotController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(-gameObject.transform.forward * speed * Time.deltaTime);
        timeToDestroy -= Time.deltaTime;

        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
 
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<PlayerController>().GotHit();

        }

        if (other.gameObject.tag == "DestructibleWall")
        {

            Destroy(gameObject);
        }
        if (other.gameObject.tag == "IndestructibleWall")
        {

            Destroy(gameObject);
        }

    }

}
