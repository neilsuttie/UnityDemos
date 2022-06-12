using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 myVelocity = Vector3.zero;

    public float mySpeed;

    private Rigidbody myRigidBody; 

    private float rayLength = 100f;

    private int myLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();

        myLayerMask = LayerMask.GetMask("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
        Turn();
    }

    private void Move(float horizontal, float vertical)
    {
        myVelocity.Set(horizontal, 0f, vertical);

        myVelocity = myVelocity.normalized * mySpeed * Time.deltaTime;

        myRigidBody.MovePosition(myRigidBody.position + myVelocity);
    }

    private void Turn()
    {
        Ray cameraToMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast(cameraToMouse, out floorHit, rayLength, myLayerMask))
        {
            Vector3 playerToMouse = floorHit.point - myRigidBody.position;

            playerToMouse.y = 0;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            myRigidBody.MoveRotation(newRotation);
        }


    }
}
