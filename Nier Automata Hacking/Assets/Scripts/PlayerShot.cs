using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OrangeShot")
        {
            Destroy(gameObject);
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
