using UnityEngine;

/// <summary>
/// More advanced implmentation of the audio trigger script.
/// Now we can chose to play the sound at another location in the game world.
/// We can also randomise which sound we play.
/// We can also choose to play the sound only once.
/// </summary>
public class AudioTrigger_v3 : MonoBehaviour
{
    //A boolean flag to track whether or not the designer wants this audio trigger to be a once time event i.e. it will not play a second time
    public bool playOnce;
    //A boolean flag to track whether we want to choose at random audio sample when the game starts that can be played mutiple times
    public bool randomiseOnStart;
  
    //Reference to a Unity component of type AudioSource. A AudioSource is attached to a Unity GameObject for playing sounds in a 3D environment.
    private AudioSource sound;
    //Reference to a game object which represents a location at which to play the audio
    public GameObject playAtLocation;
    // A list of potential audio clips so we can randomise the sound played. "[]" donates a list of the same type 
    public AudioClip[] soundSamples;

    // Use this for initialization
    void Start()
    {
        //Fetch the audio source component we are going to use to play the audio clips
        sound = GetComponent<AudioSource>();

        //IF we want to choose a random sound for this trigger AND '&&' has the designer actually added any sounds to the list then... 
        if(randomiseOnStart == true && soundSamples.Length > 0)
        {
            //reassign the audio clip parameter on our aduio source to a random sample from the list on this script.

            //First get a random number to choose which clip
            int random = (int)Random.Range(0, soundSamples.Length);

            //Assign a random clip to the audio clip parameter on the AudioSource component
            sound.clip = soundSamples[random];
        }
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
        if (playOnce == true)
        {
            //Delete the trigger game object and the target point game object
            Destroy(gameObject);
            Destroy(playAtLocation);
        }
    }
}

