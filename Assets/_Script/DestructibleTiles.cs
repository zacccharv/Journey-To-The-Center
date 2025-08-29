using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class DestructibleTiles : MonoBehaviour
{
    
    public Tilemap tilemap;
   
    private int tilePosY = 1;
    private float offSetY = 0.5f;
    private float sizeY = 1f;
    [SerializeField] GridLayout grid;
    [SerializeField] BoxCollider2D tileCollider;


    

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            tilePosY--;
           
            tilemap.SetTile(new Vector3Int(36, tilePosY,0), null);
            tileCollider.size = new Vector2(tileCollider.size.x, tileCollider.size.y - sizeY);
            tileCollider.offset = new Vector2(tileCollider.offset.x, tileCollider.offset.y - offSetY);
            
        }
    }
   
}
