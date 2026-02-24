namespace LightPuzzle.Tiles
{
	public class Receiver : Tile
	{
		public bool IsReceivingBeam { get; private set; }

		public override void HandleBeam(bool receiving)
		{
			IsReceivingBeam = receiving;
		}

		public override bool IsBeamModifier() => false;
	}
}