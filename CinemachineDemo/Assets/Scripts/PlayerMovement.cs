using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Vector3 velocity;
    public float speed = 6.0f;

    private Rigidbody myRigidBody;

    private int floorMask;
    private float cameraRayLength = 100f;

    public bool isMovementLocked = false;

	// Use this for initialization
	void Start ()
    {
        floorMask = LayerMask.GetMask("Floor");

        myRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (!isMovementLocked)
        {
            Move(horizontal, vertical);
            Turn();
        }
	}

    private void Move(float horizontal, float vertical)
    {
        velocity.Set(horizontal, 0.0f, vertical);

        velocity = velocity.normalized * speed * Time.deltaTime;

        myRigidBody.MovePosition(myRigidBody.position + velocity);
    }

    private void Turn()
    {
        Ray cameraRayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast (cameraRayCast, out floorHit, cameraRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - myRigidBody.position;

            playerToMouse.y = 0.0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            myRigidBody.MoveRotation(newRotation);
        }
    }
}
