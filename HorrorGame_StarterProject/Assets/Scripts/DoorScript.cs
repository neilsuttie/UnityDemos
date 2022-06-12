using UnityEngine;
using System;

[Flags]
public enum DoorStates
{
    open, closed, locked, slammed
}

public class DoorScript : MonoBehaviour, IInteractable {

    public DoorStates _doorState = DoorStates.closed;

    //Editor values
    public float _openAngle = 80.0f;
    public float _speed = 1f;

    //Vector3 Rotations
    private Vector3 _closedRotation;
    private Vector3 _openRotation;

    //Audio
    private AudioSource _audio;
    public AudioClip _creakAudio;
    public AudioClip _lockedAudio;
    public AudioClip _unlockAudio;
    public AudioClip _slamAudio;

    private void Start()
    {
        //Set the Vector3 closed rotation to the doors current rotation
        _closedRotation = transform.eulerAngles;
        //Door rotates about pivot in the y axis. Set the X,Z components to the closed rotation. Set Y to the closed rotation + the open angle
        _openRotation = new Vector3(_closedRotation.x, _closedRotation.y + _openAngle, _closedRotation.z);

        _audio = GetComponent<AudioSource>();
       
    }

    public void Interact()
    {
        switch (_doorState)
        {
            case DoorStates.open:
                _doorState = DoorStates.closed;
                _audio.clip = _creakAudio;
                break;

            case DoorStates.closed:
                _doorState = DoorStates.open;
                _audio.clip = _creakAudio;
                break;

            case DoorStates.locked:
                //Do we have the key?
                Inventory playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
                String keyID = gameObject.name + "Key";

                if (playerInventory.Contains(keyID))
                {
                    //Remove the key from the player inventory
                    playerInventory.Remove(keyID);
                    //Unlock the door
                    _doorState = DoorStates.closed;
                    _audio.clip = _unlockAudio;
                }
                else
                {
                    //Door remains locked
                    _audio.clip = _lockedAudio;
                }
                break;

            case DoorStates.slammed:
                _audio.clip = _slamAudio;
                _speed = 10f;
                _doorState = DoorStates.closed;
                break;

            default:
                break;
        }
        //Play the selected Audio
        _audio.Play();
    }

    private void Update()
    {
        if(_doorState == DoorStates.open)
       {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, _openRotation, Time.deltaTime * _speed);
        }
       else if(_doorState == DoorStates.closed) {
           transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, _closedRotation, Time.deltaTime * _speed);
       }
    }
}
