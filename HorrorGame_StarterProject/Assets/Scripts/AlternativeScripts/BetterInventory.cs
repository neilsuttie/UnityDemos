using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to contain a player inventory and process additions/substracts etc.
/// </summary>
public class Inventory : MonoBehaviour
{

    private List<string> myInventory;

    [Tooltip("Optional text field to output useful information")]
    public Text TextField;

    private void Start()
    {
        //Initalise the list. The editor does this step for us if the variable is public otherwise we need to do it ourselves.
        myInventory = new List<string>();
    }

    public void AddInventoryItem(string item)
    {
        if(TextField)
            displayMessage("You have added " + item + " to your inventory", 2f);

        if (myInventory != null)
            myInventory.Add(item);
    }

    /// <summary>
    /// Check if the players inventory contains the item identified by the string argument
    /// </summary>
    /// <param name="item">The ID of the object</param>
    public bool Contains(string item)
    {
        return myInventory.Contains(item) ? true : false;
    }

    public void Remove(string item)
    {
        if (TextField)
            displayMessage("You have removed " + item + " from your inventory", 2f);

        if (myInventory != null)
            myInventory.Remove(item);
    }

    public void displayMessage(string message)
    {
        if(TextField)
        TextField.text = message;
    }

    public void displayMessage(string message, float time)
    {
        displayMessage(message);

        Invoke("ClearHUD", time);
    }

    public void ClearHUD()
    {
        //Clear the text label
        TextField.text = "";
    }
}
