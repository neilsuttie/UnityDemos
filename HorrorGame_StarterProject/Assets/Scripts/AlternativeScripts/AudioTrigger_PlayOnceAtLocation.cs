using UnityEngine;

/// <summary>
/// More advanced implementation of the audio trigger script.
/// Now we can chose to play the sound at another location in the game world.
/// We can also choose to play the sound only once.
/// </summary>
public class AudioTrigger_v2 : MonoBehaviour
{
    //A boolean flag to track whether or not the designer wants this audio trigger to be a once time event i.e. it will not play a second time
    public bool playOnce;
  
    //Reference to a Unity component of type AudioSource. A AudioSource is attached to a Unity GameObject for playing sounds in a 3D environment.
    private AudioSource sound;
    //Reference to a game object which represents a location at which to play the audio
    public GameObject playAtLocation;

    // Use this for initialization
    void Start()
    {
        //Fetch the audio source component we are going to use to play the audio clips
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the designer has NOT (i.e. it still has a NULL value) assigned a seperate location object to play this audio in the editor. Assume we play the audio at the location of this game object. 
        if (playAtLocation == null)
        {
            //assign the location at which to the play the sound to the same location as the game object this script is attached to
            playAtLocation = gameObject;
        }

        //Regardless or whether we play the audio at a different location or at the current location we can use PlayClipAtPoint and not sound.Play()
        //This allows us to destroy the object this audio source is attached to if we only want to trigger this sound once
        AudioSource.PlayClipAtPoint(sound.clip, playAtLocation.transform.position);

        //If we want to only play the audio once
        if(playOnce == true)
        {
            //Delete the trigger game object and the target point game object
            Destroy(gameObject);
            Destroy(playAtLocation);
        }
    }
}

