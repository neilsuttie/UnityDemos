using UnityEngine;

public class AudioTrigger : MonoBehaviour {


    public AudioSource _audio;
    // Use this for initialization
    void Start () {
        _audio = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(_audio.clip, this.gameObject.transform.position); 
        Destroy(gameObject);
    }
}
