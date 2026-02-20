using System;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public bool IsInteractable
    {
        get => isInteractable;
        set => isInteractable = value;
    }

    public event Func<bool> InteractionTest = null;

    [SerializeField] private bool isInteractable = true;

    public void OnMouseUpAsButton()
    {
        bool? interactionTest = InteractionTest?.Invoke();

        if (isInteractable && (interactionTest.HasValue ? interactionTest.Value : true))
        {
            OnInteracted();
        }
    }

    protected virtual void OnInteracted() { }
}
