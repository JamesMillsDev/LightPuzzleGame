namespace LightPuzzle.Tiles
{
    public class SidedTile : Tile
    {
        public Direction validSides = Direction.All;

        public override bool IsValidBeamSide(Direction direction) => (direction & validSides) == direction;
    }
}
