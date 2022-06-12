using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_QuickFlip : MonoBehaviour
{
    private Flip[] components;
    private Swing _swingBulb;

    private void Start()
    {
        components = GameObject.FindObjectsOfType<Flip>();
    }

    public void FlipIt()
    {
        foreach (Flip flip in components)
        {
            flip.FlipIt();
        }
    }

    public void SwingIt()
    {
        GameObject.FindObjectOfType<Swing>().SwingIt();
    }
    public void ResetObjects()
    {
        foreach (Flip flip in components)
        {
            flip.Reset();
        }

        GameObject.FindObjectOfType<Swing>().Reset();
    }
}
