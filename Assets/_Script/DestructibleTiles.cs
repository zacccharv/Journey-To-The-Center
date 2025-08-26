using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class DestructibleTiles : MonoBehaviour
{
    
    public Tilemap tilemap;
   
    private int tilePosY = 1;
    [SerializeField] GridLayout grid;

    

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            tilePosY--;
           
            tilemap.SetTile(new Vector3Int(0,tilePosY,0), null);
           
        }
    }
   
}
