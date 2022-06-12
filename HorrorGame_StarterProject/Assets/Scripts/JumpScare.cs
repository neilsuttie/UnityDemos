using UnityEngine;

public class JumpScare : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Get a reference to the light bulb in the room
            GameObject lightBulb = GameObject.Find("SwingingBulb");
            //Add a physics force to swing the light bulb
            lightBulb.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 200f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Slam the door behind the player as the enter the room
            GameObject door = GameObject.Find("RedDoor");
            door.GetComponent<DoorScript>()._doorState = DoorStates.slammed;
            door.GetComponent<DoorScript>().Interact();

            //Turn off the player's flashlight
            Flashlight flashLight = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Flashlight>();
            if (flashLight._isOn)
            {
                flashLight.Toggle();
            }

            //Disable the flashlight so the player can't reactivate
            flashLight.enabled = false;

            //fade the lamp to darkness
            GameObject light = GameObject.Find("SwingingBulb");
            light.GetComponent<LightBulb>().SetEmissiveMaterial(false);
            light.GetComponent<LightBulb>().FadeToBlack();

            //Give the door time to close and lock it
            Invoke("LockDoor", 1f);

            //Disable the trigger to prevent the player reactivating the trigger before we destroy the trigger object
            gameObject.GetComponent<Collider>().enabled = false;
           }
    }
    private void LockDoor()
    {
        GameObject door = GameObject.Find("RedDoor");
        door.GetComponent<DoorScript>()._doorState = DoorStates.locked;

        //We are now done with the trigger remove it
        Destroy(gameObject);
    }
}
