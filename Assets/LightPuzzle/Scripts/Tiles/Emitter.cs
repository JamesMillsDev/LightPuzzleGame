using System;
using UnityEngine;

namespace LightPuzzle.Tiles
{
	public class Emitter : Tile
	{
		[SerializeField] private Direction emissionDirection = Direction.East;
		[SerializeField] private LightBeam lightBeam;

		[SerializeField] private bool drawEmitters;
		[SerializeField] private Transform northEmitter;
		[SerializeField] private Transform eastEmitter;
		[SerializeField] private Transform southEmitter;
		[SerializeField] private Transform westEmitter;

		public void SetActive(bool active)
		{
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Transform emitter = GetEmitter();
				lightBeam.Emit(emitter.position, emitter.right, gameObject);
			}
		}

		private Transform GetEmitter()
		{
			return this.emissionDirection switch
			{
				Direction.North => this.northEmitter,
				Direction.East => this.eastEmitter,
				Direction.South => this.southEmitter,
				Direction.West => this.westEmitter,
				_ => throw new InvalidOperationException("Invalid emission direction.")
			};
		}

		public override bool IsBeamModifier() => false;

		private void OnDrawGizmos()
		{
			if (this.northEmitter == null || this.eastEmitter == null ||
			    this.southEmitter == null || this.westEmitter == null || !drawEmitters)
			{
				return;
			}
			
			DrawEmitter(this.northEmitter, Color.blue);
			DrawEmitter(this.eastEmitter, Color.red);
			DrawEmitter(this.southEmitter, Color.green);
			DrawEmitter(this.westEmitter, Color.yellow);
		}

		private static void DrawEmitter(Transform emitter, Color color)
		{
			Gizmos.color = color;
			Gizmos.DrawRay(emitter.position, emitter.right);
		}
	}
}