using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    int Force;
    int Ammo = 50;

    Transform CameraCannon;

    public Camera mainCamera;
    public GameObject Ball;
    public GameObject SpawnPoint;

    GameObject BallInstance;

   

    void Start()
    {
        CameraCannon = gameObject.transform.GetChild(0);        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        
        Vector3 globalPosition = mainCamera.ScreenToWorldPoint(new Vector3(
            mousePosition.x,
            mousePosition.y,
            CameraCannon.position.z - mainCamera.transform.position.z
            ));        

        CameraCannon.transform.LookAt(globalPosition);


        if (Input.GetMouseButtonDown(0) && Ammo > 0)
        {
            BallInstance = Instantiate(Ball, SpawnPoint.transform.position, Ball.transform.rotation);
            Rigidbody BallridgyBody = BallInstance.GetComponent<Rigidbody>();
            
            BallridgyBody.AddForce((globalPosition - CameraCannon.transform.position)*Force);
            Ammo--;
        }
        





    }
}
