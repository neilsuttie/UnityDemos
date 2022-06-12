using UnityEngine;
using UnityEngine.UI;

public class FlashlightAdvanced : MonoBehaviour
{
        //Internal state of this Flashlight. This is essential our flashlight's on/off switch. We will start on the off position unless overriden by the editor.
    public bool isOn = false;

    //Reference to the light source we are controlling. Set via the editor. This version of the script does not assume this script is on the same object as the light source. 
    public Light spotlight;


    //Battery Info
    //The current power in our 'battery' as a percentage. We assume we always start at 100%
    private float currentBatteryPercentage = 100.00f;
    //The percentage of battery power we remove on each 'tick'. Public so we can edit it from Unity (3.0f == 3%)
    public float amountToDrain = 3.00f;
    //How often we will 'tick' down the battery. 1.0f == 1 second.
    public float BatteryTimer = 2.00f;

    //Reference to the battery icon on the player UI
    public Image batteryIcon;

	// Use this for initialization
	void Start ()
    {
        //If the flashlight is on at the start of the level. Start draining. Don't wait for a button press. Gives our designer the choice to have it off or on be default.
        //Although, what happens if we uncheck it via the editor while the battery is draining?
        if(isOn)
        {
            StartDrainingBattery();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Toggle the internal state (on/off) of the flashlight when the user presses the f key. This action is handled by the custom function 'Toggle'
        //If the user presses f  AND we have more battery left than we drain in one tick we 'turn on' and start draining the battery
        if (Input.GetKeyDown("f") && (currentBatteryPercentage >= amountToDrain))
        {
            Toggle();
        }

        //We control the on/off state of the attached light source
        //We do this in update so the light stays synced with the light source should the flashlight state be flipped somewhere other than during the Toggle function
        spotlight.enabled = isOn;
	}

    
    //Perform the behaviours assoicated with toggling the players flashlight
    private void Toggle()
    {
        //Flip the state of the flashlight i.e. is the button in the on position or off position?
        isOn = !isOn;

        //If the flashlight 'button' is now in the on position
        if(isOn)
        {
            //Call the custom function StartDrainingBattery which controls this behaviour
            StartDrainingBattery();
        }
        else //we must now be in the off position. Stop draining the battery.
        {
            StopDrainingBattery();
        }
    }

    //Custom function we 'call' when we want to START draining the 'internal' battery that belongs to this flashlight
    private void StartDrainingBattery()
    {
        //Invoke repeating is a special Unity function that allows you to schedule functions to execute at a later time
        //We give it the name of the function we want to execute, how far into the future do we want it to execute, and a 3rd value if we want to repeat at regular intervals.
        //InvokeRepeating("methodName", timeUntilExecute, RepeatAfterSeconds)
        InvokeRepeating("DrainBattery", BatteryTimer, BatteryTimer);
    }

    //Function that is called every battery 'tick' that decrements the amount of battery power remaining when called. Stops the process once the battery is delepleted
    //Note the tick rate is set by the Invoke. It is not tied to the update tick.
    private void DrainBattery()
    {
        //Do we have enough power left to perform a drain action i.e. is the remaining amount greater than the amount we drain per 'tick'
        if(currentBatteryPercentage > amountToDrain)
        {
            //If we do have enough...reduce the remaining power by the amount we drain per tick
            currentBatteryPercentage -= amountToDrain;
        }
        else
        {
            //Zero out the value just to make sure it didn't become negative during the last substraction. Otherwise might cause problems with our UI elementS
            currentBatteryPercentage = 0.0f;
            //Flip the value of isOn to off
            isOn = false;
            //Now stop periodically calling this function our battery is completely drained already.
            StopDrainingBattery();
        }

        //Attempt to update the player indicator
        UpdateIcon();

    }


    //Custom function we 'call' when we want to STOP draining the 'internal' battery that belongs to this flashlight
    private void StopDrainingBattery()
    {
        //Cancel all the scheduled Invoked function calls begun by this script.
        CancelInvoke();
    }

    //Updates the UI Icon
    public void UpdateIcon()
    {
        //Only try and update the battery icon if it has been assigned.
        if(batteryIcon != null)
        batteryIcon.fillAmount = currentBatteryPercentage / 100.00f;

        Debug.Log("The current battery percentage is " + currentBatteryPercentage + "%");
    }


}
