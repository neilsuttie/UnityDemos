using UnityEngine;

public class Highlighter : MonoBehaviour {

    public Color _color;
    public string _guiMessage;

    private Component[] _renderers;
    private HUD _playerHUD;

    private void Start()
    {
       //Does the object this script attached to have a material?
       if(gameObject.GetComponent<Renderer>() != null)
        {
            _renderers = new Renderer[] { null };
           _renderers[0] = GetComponent<Renderer>();
        }
        //Otherwise does its children? (i.e. is the collider on a top-level empty object?)
      else if(gameObject.GetComponent<Renderer>() == null)
        {
            _renderers = GetComponentsInChildren<Renderer>();
        }

        _playerHUD = GameObject.FindWithTag("HUD").GetComponent<HUD>();
    }
    private void OnMouseOver()
    {
        foreach (Renderer renderer in _renderers)
            renderer.material.SetColor("_EmissionColor", _color);

        _playerHUD.displayMessage(_guiMessage);
    }

    private void OnMouseExit()
    {
        foreach (Renderer renderer in _renderers)
           renderer.material.SetColor("_EmissionColor", Color.black);

        _playerHUD.ClearHUD();
    }
}
