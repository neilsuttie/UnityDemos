using UnityEngine;

public class DoorControllerUsingAnimator : MonoBehaviour
{
    //Reference to our animator component. This is where our AnimController lives
    //Marked as public so we can assign the object we are animating via the Editor 
    public Animator myAnimator;

    //FLAGS
    bool isOpen = false;                //Is the door open or closed?
    bool isPlayerNear = false;        //Is the player in the interaction area?


    // Update is called once per frame
    void Update ()
    {
        //Everytime the game updates we check if the player is near the door and has pressed the open key
        //We use the conditional AND operator (&&) to make sure we can only open/close the door when we are BOTH near the door and have pressed the correct key
        if(Input.GetKeyDown("e") && isPlayerNear == true)
        {
            //Assign isOpen the opposite of its current value. True becomes false false becomes true. Open becomes closed etc.
            isOpen = !isOpen;
        }

        //Pass the value of our bool variable isOpen to the parameter we set up in the AnimationController. The names don't have to match they are seperate variables but
        //The first argument must match the paramater we want change in the animation cotroller. This is case senstive. 
        myAnimator.SetBool("isOpen", isOpen);
	}

    //Unity event function OnTriggerEnter
    //If a collider marked as a trigger is attahced to the same object as this script, this function is executed when a collision between two objects is detected.
    //(Collider other) is the Collider component attached to the other object involoved in the collision. Both objects must have collider components.
    private void OnTriggerEnter(Collider other)
    {
        //First we check that the other collider belongs to the Player by comparing it's tag. We don't want a random object in the trigger area to allow us to open the door from 
        //anywhere on the map
        if (other.gameObject.tag == "Player")
        {
            //We set the value of the interactable flag to false when the player enters the area
            isPlayerNear = true;
        }
    }

    //Unity event function OnTriggerExit
    //If a collider marked as a trigger is attahced to the same object as this script, this function is executed when a GameObject exits a collider. 
    //(Collider other) is the Collider component attached to the other object involoved in the collision. Both objects must have collider components.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //We set the value of the interactable flag to false when the player exits the area
            isPlayerNear = false;
        }
    }
}
