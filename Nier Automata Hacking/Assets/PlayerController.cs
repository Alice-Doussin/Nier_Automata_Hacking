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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey("up")||Input.GetAxis("Vertical")>0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward*speed * Time.deltaTime);
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

        gameObject.GetComponent<Rigidbody>().rotation = Quaternion.Lerp(gameObject.GetComponent<Rigidbody>().rotation, Quaternion.Euler(new Vector3(0, Mathf.Atan2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * 180 / Mathf.PI + 90, 0)), Time.deltaTime * rotationSpeed);
        //Quaternion.Euler(new Vector3(0, Mathf.Atan2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * 180/Mathf.PI +90, 0));

    }
}
