using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Custom Rule Tile", menuName = "Tiles/Custom Rule Tile")]
public class CustomRuleTile : RuleTile
{
    // This method is necessary to define the possible neighbors for the tile
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
    }

    // Override the RuleMatches method to add custom logic
    public override bool RuleMatch(int neighbor, TileBase other)
    {
        if (other is CustomRuleTile)
        {
            // Custom logic: treat certain tiles as occupied
            return true;
        }

        // Fall back to the base method if custom conditions are not met
        return base.RuleMatch(neighbor, other);
    }


}
