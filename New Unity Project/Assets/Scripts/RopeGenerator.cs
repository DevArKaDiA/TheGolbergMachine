using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public int offsetSize;

    public GameObject pointA;
    public GameObject pointB;
    public GameObject Ropelink;

    public GameObject[] Ropelinks;

    Rigidbody rgbPointA;
    Rigidbody rgbPointB;


    CapsuleCollider ColliderRopelink;




    void Start()
    {
        rgbPointA = pointA.GetComponent<Rigidbody>();
        rgbPointB = pointB.GetComponent<Rigidbody>();
        ColliderRopelink = Ropelink.GetComponent<CapsuleCollider>();

        float dis = Vector3.Distance(pointB.transform.position, pointA.transform.position);
        int NumberofJoints = Mathf.RoundToInt(dis / ColliderRopelink.height) + offsetSize;
        Ropelinks = new GameObject[NumberofJoints];

        for (int i = 0; i < NumberofJoints; i++)
        {
            GameObject link = Instantiate(Ropelink);
            FixedJoint joint = link.GetComponent<FixedJoint>();

            Ropelinks[i] = link;
            if (i == 0)
            {
                joint.connectedBody = rgbPointA;                
            }
            else if(i != 0 && i < NumberofJoints-1)
            {
                joint.connectedBody = Ropelinks[i - 1].GetComponent<Rigidbody>();
            }
            else
            {
                joint.connectedBody = Ropelinks[i - 1].GetComponent<Rigidbody>();
                FixedJoint secondJointlink = link.AddComponent<FixedJoint>();
                secondJointlink.connectedBody = rgbPointB;
            }        
                
            

            
            
        }

        
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
