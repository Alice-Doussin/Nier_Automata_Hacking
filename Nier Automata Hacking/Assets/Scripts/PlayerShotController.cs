using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward * speed * Time.deltaTime);
        gameObject.GetComponent<Rigidbody>().AddForce(-gameObject.transform.forward * speed * Time.deltaTime);

    }
}
