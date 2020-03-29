using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public int offsetSize; 
    public GameObject Ropelink;
    public int links;
    public GameObject[] Ropelinks;

    GameObject A;
    GameObject B;

    CapsuleCollider ColliderRopelink;

    bool isrunnig = false;

    void start()
    {
        isrunnig = !isrunnig;
     



    }
    IEnumerator Destroy(GameObject go)
    {
        yield return new WaitForEndOfFrame();
        DestroyImmediate(go);
    }
    void OnValidate()
    {
        if (!isrunnig)
        {            
            StartCoroutine(Destroy(A));
            StartCoroutine(Destroy(B));

            for (int i = 0; i < Ropelinks.Length; i++)
            {            
                StartCoroutine(Destroy(Ropelinks[i]));
            }

            A = Instantiate(Ropelink);
            A.AddComponent<Rigidbody>();
            A.name = "A";

            B = Instantiate(Ropelink);
            B.AddComponent<Rigidbody>();
            B.name = "B";



            ColliderRopelink = Ropelink.GetComponent<CapsuleCollider>();

            int NumberofJoints = links;
            Ropelinks = new GameObject[NumberofJoints];
           

            float space = 0.25f;

            for (int i = 0; i < NumberofJoints; i++)
            {

                if (i == 0)
                {
                    Ropelinks[i] = Instantiate(Ropelink);
                    
                    FixedJoint joint = A.AddComponent<FixedJoint>();
                    joint.connectedBody = Ropelinks[i].GetComponent<Rigidbody>();
                    A.transform.position = Ropelinks[i].transform.position;

                }

                if (i > 0 && i < NumberofJoints)
                {
                    Ropelinks[i] = Instantiate(Ropelink, new Vector3(
                        Ropelinks[i - 1].transform.position.x + space,
                        Ropelinks[i - 1].transform.position.y,
                        Ropelinks[i - 1].transform.position.z
                        ), Ropelinks[i - 1].transform.rotation);

                    FixedJoint joint = Ropelinks[i].GetComponent<FixedJoint>();
                    joint.connectedBody = Ropelinks[i - 1].GetComponent<Rigidbody>();
                }
                if (i == NumberofJoints - 1)
                {
                    B.transform.position = Ropelinks[i - 1].transform.position;
                    FixedJoint joint2 = B.AddComponent<FixedJoint>();

                }
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
