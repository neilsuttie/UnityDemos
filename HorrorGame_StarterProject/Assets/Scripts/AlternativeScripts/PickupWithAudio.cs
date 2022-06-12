using UnityEngine;

public class PickupWithAudio : MonoBehaviour
{
    public AudioClip myAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            //Use PlayClipAtPoint as we delete this object. This spawns a new audio source that plays clip before removing itelf from the scene.
            AudioSource.PlayClipAtPoint(myAudioClip, this.gameObject.transform.position);
            //find the players inventory when they collide with the trigger around this pick. 
            //Then add the name of this game object as an item into the player's inventory
            other.GetComponent<PlayerInventory>().myInventory.Add(gameObject.name);
            //Remove the object from the scene to "pick" it up
            Destroy(gameObject);
        }
    }
}
