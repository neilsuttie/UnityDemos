using UnityEngine;

public class Raycast : MonoBehaviour {

    private RaycastHit _raycastHit;
    private Vector3 _forward;

    public float _rayLength;

	// Update is called once per frame
	void Update () {

        _forward = transform.TransformDirection(Vector3.forward);
      //  Debug.DrawRay(transform.position, _forward * _rayLength, Color.green);
  
        //If out raycast collides with an object
        if(Physics.Raycast (transform.position, _forward, out _raycastHit))
        {
           // Debug.Log("The distane is " + _raycastHit.distance);
            Debug.Log("The target object is " + _raycastHit.collider.gameObject.name);

            //Get the game object
            GameObject objectHit = _raycastHit.collider.gameObject;

            //Is the player interacting with the object?
            if (Input.GetKeyDown("e"))
            {
                //Is the object a collectable object or an interactable objects
                if (objectHit.tag == "Interactable")
                {
                    Debug.Log("Interacting with " + objectHit.name);
                    objectHit.GetComponent<IInteractable>().Interact();
                }
                else if(objectHit.tag == "Collectable")
                {
                    //Get the player invetory add add the item. Destroy the item
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddInventoryItem(objectHit.name);
                        Destroy(objectHit);
                }
            }
        }
    }
}

