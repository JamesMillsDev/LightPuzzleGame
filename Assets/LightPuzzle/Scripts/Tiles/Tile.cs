using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public bool IsInteractable
    {
        get => isInteractable;
        set => isInteractable = value;
    }

    public event Func<bool> InteractionTest;

    [SerializeField] private bool isInteractable = true;

    public void OnMouseUpAsButton()
    {
        if (isInteractable && InteractionTest.Invoke())
        {
            OnInteracted();
        }
    }

    protected virtual void OnInteracted() { }
}
