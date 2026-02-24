using System;
using UnityEngine;

namespace LightPuzzle
{
	public class InteractionController : MonoBehaviour
	{
		public bool IsInteractable
		{
			get => this.isInteractable;
			set => this.isInteractable = value;
		}

		[SerializeField] private bool isInteractable = true;
		
		public Action onInteracted;
		
		public void OnMouseUpAsButton()
		{
			if (this.isInteractable)
			{
				onInteracted?.Invoke();
			}
		}
	}
}