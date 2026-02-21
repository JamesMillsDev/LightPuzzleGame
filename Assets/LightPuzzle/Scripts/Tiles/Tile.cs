using System;
using UnityEngine;

namespace LightPuzzle.Tiles
{
    public abstract class Tile : MonoBehaviour
    {
        public bool IsInteractable
        {
            get => this.isInteractable;
            set => this.isInteractable = value;
        }

        public event Func<bool> InteractionTest;

        [SerializeField] private bool isInteractable = true;

        public void OnMouseUpAsButton()
        {
            bool? interactionTest = this.InteractionTest?.Invoke();

            if (this.isInteractable && (interactionTest ?? true))
            {
                OnInteracted();
            }
        }

        protected virtual void OnInteracted() { }
    }
}
