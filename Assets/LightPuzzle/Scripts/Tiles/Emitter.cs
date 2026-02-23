using UnityEngine;

namespace LightPuzzle.Tiles
{
	public class Emitter : Tile
	{
		[SerializeField] private Direction emissionDirection = Direction.East;

		public void SetActive(bool active)
		{
			
		}
	}
}