using System;
using LightPuzzle.Utility;
using UnityEngine;

namespace LightPuzzle.Tiles
{
	public class RotatableMirror : Mirror, IRotatable
	{
		public float RotateAmount => 90f;

		public float RotateTime => this.rotationTime;

		[SerializeField] private InteractionController interactionController;

		[SerializeField] private AnimationCurve smoothingCurve;
		[SerializeField] private float rotationTime = 1f;

		public Func<float, float> GetSmoothingFunction() => time => this.smoothingCurve.Evaluate(time);

		private void OnEnable()
		{
			if (this.interactionController != null)
			{
				this.interactionController.onInteracted += OnInteracted;
			}
		}

		private void OnDisable()
		{
			if (this.interactionController != null)
			{
				this.interactionController.onInteracted -= OnInteracted;
			}
		}
		
		private void OnDrawGizmosSelected()
		{
			if ((this.validSides & Direction.North) == Direction.North)
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.up);
			}

			if ((this.validSides & Direction.East) == Direction.East)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.right);
			}

			if ((this.validSides & Direction.South) == Direction.South)
			{
				Gizmos.color = Color.green;
				Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.down);
			}

			if ((this.validSides & Direction.West) == Direction.West)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.left);
			}
		}

		private void OnInteracted()
		{
			interactionController.IsInteractable = false;
			StartCoroutine(
				TransformUtilities.Rotate(this.transform, this.RotateAmount, this.RotateTime,
					() => interactionController.IsInteractable = true,
					GetSmoothingFunction()
				)
			);

			RotateValidSides();
		}

		private void RotateValidSides()
		{
			if ((this.validSides & (Direction.North | Direction.West)) == (Direction.North | Direction.West))
			{
				this.validSides = Direction.South | Direction.West;
				return;
			}

			if ((this.validSides & (Direction.North | Direction.East)) == (Direction.North | Direction.East))
			{
				this.validSides = Direction.North | Direction.West;
				return;
			}

			if ((this.validSides & (Direction.South | Direction.West)) == (Direction.South | Direction.West))
			{
				this.validSides = Direction.South | Direction.East;
				return;
			}

			if ((this.validSides & (Direction.South | Direction.East)) == (Direction.South | Direction.East))
			{
				this.validSides = Direction.North | Direction.East;
			}
		}
	}
}