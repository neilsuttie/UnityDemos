using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Game object component references
    private Rigidbody myRigidBody;
    private Animator myAnimator;

    private bool isRunning = false;

    //We've got a acceleration value for walk and run
    //So we transistion from Idle to Run faster than Idle to Walking
    //This is the force applied to Rigidbody along the direction vector(velocity)
    private float _acceleration = 20.0f;
    [SerializeField] float _walkAcceleration = 20.0f;
    [SerializeField] float _runAcceleration = 40.0f;

    //MaxVelocity used to clamp the rigidbodies max speed based on the characters movement
    //type
    private float maxVelocity = 3.0f;
    private float maxVelocitySquared;
    [SerializeField] float maxWalkVelocity = 3.0f;
    [SerializeField] float maxRunVelocity = 5.0f;

    //The speed at which the character rotates to face the current velocity vector
    [SerializeField] float turningSpeed = 3.0f;

    // Use this for initialization
    void Start()
    {
        //Get our attached components
        myRigidBody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();

        //Set up rigidbody contraints
        myRigidBody.constraints =
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationZ;

        //Intialise the mexVelocitySquared. Used during velocity limitation
        maxVelocitySquared = maxVelocity * maxVelocity;

        //Set the default acceleration to the walk speed
        _acceleration = _walkAcceleration;
    }

    private void FixedUpdate()
    {
        //Get the input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = 0.0f;
    //    float vertical = Input.GetAxis("Vertical");

        //Check if the player is running. Use "Jump" which is the default flag for the space bar
        isRunning = Input.GetButton("Jump");

        //Assign the X,Z axes the values of vertical and horiontal respectively
        Vector3 velocity = vertical * Vector3.forward + horizontal * Vector3.right;
        //Apply the current acceleration to the rigid body along this direction vector (velocity)
        ApplyAcceleration(velocity);

        //Use myRigidBody's velocity since velocity is normalised durring apply
         myAnimator.SetFloat("speed", myRigidBody.velocity.magnitude);
    }

    private void ApplyAcceleration(Vector3 velocity)
    {
        //Normalise the vector if grater than 1.
        if (velocity.magnitude > 1f) velocity.Normalize();

        //Are we running or walking? Assign velocity values accordingly
        _acceleration = (isRunning) ? _runAcceleration : _walkAcceleration;
        maxVelocity = (isRunning) ? maxRunVelocity : maxWalkVelocity;
        maxVelocitySquared = maxVelocity * maxVelocity;

        //add the force the to the rigidbody
        myRigidBody.AddForce(velocity * _acceleration);

        //Set the player rotation
        if (myRigidBody.velocity.sqrMagnitude > 0.01f)
        {
            Quaternion newRotation = Quaternion.Slerp(
              myRigidBody.rotation,
               Quaternion.LookRotation(myRigidBody.velocity.normalized),
              Time.deltaTime * turningSpeed);
            myRigidBody.MoveRotation(newRotation);
        }


        //Limit the maximum velcoity of the object
        if (myRigidBody.velocity.sqrMagnitude > maxVelocitySquared)
        {
            myRigidBody.velocity = myRigidBody.velocity.normalized * maxVelocity;
        }

        //If we are in the scene view render a raycast along the velocity vector
#if UNITY_EDITOR
        Debug.DrawRay(transform.position, myRigidBody.velocity, Color.green);
#endif
    }
}
