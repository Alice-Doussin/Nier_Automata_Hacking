using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreParticles : MonoBehaviour
{

    public GameObject Core;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().position = Core.GetComponent<Transform>().position;
    }
}
