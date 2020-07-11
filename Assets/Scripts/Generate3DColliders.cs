using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Generate3DColliders : MonoBehaviour
{
    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++) {
            for (int y = 0; y < bounds.size.y; y++) {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null) {
                    BoxCollider collider = gameObject.AddComponent<BoxCollider>();
                    collider.center = new Vector3(x, y, 0.0f) - new Vector3(bounds.size.x / 2.0f,bounds.size.y / 2.0f,bounds.size.z / 2.0f) + bounds.center + tilemap.tileAnchor;
                    collider.size = new Vector3(1f, 1f, 12f);
                }
            }
        } 
    }

}
