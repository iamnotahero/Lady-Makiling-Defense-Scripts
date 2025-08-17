using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;
public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField] private Tilemap floorTilemap, wallTilemap;
    [SerializeField] private TileBase floorTile, wallTop, grass, grass2, grass3, grass4;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject tree, tree2, tree3, tree4, tree5, tree6, tree7;
     [SerializeField] private GameObject barrel, crate;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions){
        PaintTiles(floorPositions, floorTilemap, floorTile);

        
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {   var floorList = new List<TileBase> { grass, grass2, grass3, grass4};
        
        
        foreach (var position in positions){
            TileBase selectedtile = floorList[Random.Range(0,floorList.Count)];
            var randomNum = Random.Range(0,20);
            PaintSingleTile(tilemap, (randomNum == 1) ? selectedtile : floorTile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    private void PaintEnemy(Tilemap tilemap, GameObject enemy, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        //tilemap.SetTile(tilePosition, enemy);
        Instantiate(enemy, tilePosition, Quaternion.identity, GameObject.Find("Enemies").transform);
        
    }

    private void PaintTree(Tilemap tilemap, GameObject tree, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        //tilemap.SetTile(tilePosition, enemy);
        Instantiate(tree, tilePosition, Quaternion.identity, GameObject.Find("Trees").transform);
        
    }    
    private void PlaceObject(Tilemap tilemap, GameObject obj, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        //tilemap.SetTile(tilePosition, enemy);
        Instantiate(obj, tilePosition, Quaternion.identity, GameObject.Find("Objects").transform);
        
    }     

    public void Clear(){
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
        ClearEnemies();
        ClearObjects();
        ClearTrees();
        //DELETE ALL CHILD OF ENEMY

    }
    private void ClearEnemies(){
        var enemiesObject = GameObject.Find("Enemies").transform;
        for(int i = enemiesObject.childCount - 1; i >= 0; i--){
            GameObject.DestroyImmediate(enemiesObject.GetChild(i).gameObject);
        }         
    }
    private void ClearObjects(){
        var objectParent = GameObject.Find("Objects").transform;
        for(int i = objectParent.childCount - 1; i >= 0; i--){
            GameObject.DestroyImmediate(objectParent.GetChild(i).gameObject);
        }         
    }
    private void ClearTrees(){
        var objectParent = GameObject.Find("Trees").transform;
        for(int i = objectParent.childCount - 1; i >= 0; i--){
            GameObject.DestroyImmediate(objectParent.GetChild(i).gameObject);
        }         
    }
    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, wallTop, position);
    }
    internal void CreateEnemy(Vector2Int position)
    {
        PaintEnemy(wallTilemap, enemy, position);
    }
    internal void CreateTree(Vector2Int position)
    {   
        var treeList = new List<GameObject> { tree, tree2, tree3, tree4, tree5, tree6, tree7};
        GameObject selectedTree = treeList[Random.Range(0,treeList.Count)];
        PaintTree(wallTilemap, selectedTree, position);
  
    }   
    internal void CreateObject(Vector2Int position)
    {   
        var objectList = new List<GameObject> {barrel, crate};
        GameObject selectedObject = objectList[Random.Range(0,objectList.Count)];
        PlaceObject(wallTilemap, selectedObject, position);
  
    }    
}
