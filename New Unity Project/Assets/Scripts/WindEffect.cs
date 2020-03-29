using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour
{
    // Start is called before the first frame update

    bool wind;
    Vector3 windForce;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wind")
        {
            windForce = other.gameObject.GetComponent<Wind>().WindForce;            
            wind = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wind")
        {
            wind = false;
        }
    }

    void FixedUpdate()
    {
        if (wind)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(windForce);
        }
    }
}
