using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator doorController;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            doorController.SetTrigger("OpenOrClose");
        }
        
    }
}
