using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ObjectGenerator
{
  public static void CreateObject(List<SampleClass> floorPositions, TilemapVisualizer tilemapVisualizer){
        var basicTreePositions = FindSpotToPlace(floorPositions, Direction2D.cardinalDirectionList);
        foreach(var position in basicTreePositions){
            tilemapVisualizer.CreateObject(position);
        }
    }

    private static HashSet<Vector2Int> FindSpotToPlace(List<SampleClass> floorPositions, List<Vector2Int> directionsList)
    {
        HashSet<Vector2Int> objectPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions){
            //Debug.Log(position);
            /*
            if (Random.Range(0,15) == 1 ){
                        objectPositions.Add(position.Mycoords);
                        position.MyhasObject = true;
            }
            */
            foreach (var direction in directionsList){
                var neighborPosition = position.Mycoords + direction;
                if(floorPositions.Find(x => x.Mycoords == neighborPosition) != null && floorPositions.Find(x => x.Mycoords == neighborPosition).MyhasObject == false && Random.Range(1,100) == 1){
                    //ebug.Log("NOT NULL");
                    floorPositions.Find(x => x.Mycoords == neighborPosition).MyhasObject  = true;
                    objectPositions.Add(neighborPosition);
                }
            }
            
        }
        return objectPositions;
    }

    public static void UpdateFloorList(){

    }
}
