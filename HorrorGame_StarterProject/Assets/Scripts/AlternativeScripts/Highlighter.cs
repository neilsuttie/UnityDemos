using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script to highlight an object when the player mouses over it. Requires a collider component to function.
/// </summary>
[RequireComponent(typeof(Collider))]
public class Highlighter : MonoBehaviour
{
    [Tooltip("Colour to tint the object on mouse over")]
    public Color tintColour;
    [Tooltip("Optional message to display on mouse over")]
    public string message;
    
    //List of the object renders. If our target object is made of multiple child objects we want to highlight them all
    private Component[] myRenderers;

    [Tooltip("Optional TextField used to display a message")]
    public Text TextField;
    
    private void Start()
    {
        //Try and find the materials on the object or children to modify on mouse over and store them all in a list

       //Does the object this script attached to have a material?
       if(gameObject.GetComponent<Renderer>() != null)
        {
            myRenderers = new Renderer[] { null };
            myRenderers[0] = GetComponent<Renderer>();
        }
        //Otherwise does its children? (i.e. is the collider on a top-level empty object?)
      else if(gameObject.GetComponent<Renderer>() == null)
        {
            myRenderers = GetComponentsInChildren<Renderer>();
        }
    }
    /// <summary>
    /// Event Function that is called when the player 'MousesOver' this particular object
    /// </summary>
    private void OnMouseOver()
    {
        //Foreach material in the list (on the object and/or its children modifiy the emissive property to that of the tintcolour
        foreach (Renderer renderer in myRenderers)
        {
            renderer.material.SetColor("_EmissionColor", tintColour);
        }

        //If we have an assigned text field. Output the stored message
        if (TextField)
            TextField.text = message;
    }
    /// <summary>
    /// Event Function that is called when the player exits 'MousesOver' this particular object
    /// </summary>
    private void OnMouseExit()
    {
        //Set all the materials emissive colours back to black
        foreach (Renderer renderer in myRenderers)
           renderer.material.SetColor("_EmissionColor", Color.black);

        //Attempt to clear the optional text field
        ClearText();
    }

    /// <summary>
    /// Function clear the message from the referenced textfield
    /// </summary>
    private void ClearText()
    {
        if (TextField)
            TextField.text = "";
    }
}
