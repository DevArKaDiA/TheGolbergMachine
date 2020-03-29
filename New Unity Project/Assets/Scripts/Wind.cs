using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public int Force;
    public Vector3 Direction;

    
    public Vector3 WindForce;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WindForce = transform.up * Force;
    }

}
