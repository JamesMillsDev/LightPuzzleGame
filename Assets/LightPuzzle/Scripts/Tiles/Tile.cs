using UnityEngine;

namespace LightPuzzle.Tiles
{
	public abstract class Tile : MonoBehaviour
	{
		public virtual bool IsBeamModifier() => true;
		
		public virtual bool IsValidBeamSide(Direction direction) => true;

		public virtual void HandleBeam(bool receiving)
		{
		}
	}
}