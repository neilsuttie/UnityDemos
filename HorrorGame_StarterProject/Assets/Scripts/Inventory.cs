using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private List<string> _inventory;
    private HUD _playerHUD;

    private void Start()
    {
        _inventory = new List<string>();

        _playerHUD = GameObject.FindWithTag("HUD").GetComponent<HUD>();
    }

    public void AddInventoryItem(string item)
    {
          _playerHUD.displayMessage("You have added " + item + " to your inventory", 2f);

          _inventory.Add(item);
    }

    /// <summary>
    /// Check if the players inventory contains the item identified by the string argument
    /// </summary>
    /// <param name="item">The ID of the object</param>
    public bool Contains(string item)
    {
        return _inventory.Contains(item) ? true : false;
    }
    public void Remove(string item)
    {
        _inventory.Remove(item);
    }
}
