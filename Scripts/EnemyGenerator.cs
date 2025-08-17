using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyGenerator 
{
  public static void CreateEnemy(List<SampleClass> floorPositions, TilemapVisualizer tilemapVisualizer){
        var basicWallPositions = FindSpotToPlace(floorPositions, Direction2D.cardinalDirectionList);
        foreach(var position in basicWallPositions){
            tilemapVisualizer.CreateEnemy(position);
        }
    }

    private static HashSet<Vector2Int> FindSpotToPlace(List<SampleClass> floorPositions, List<Vector2Int> directionsList)
    {
        HashSet<Vector2Int> enemyPositions = new HashSet<Vector2Int>();
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
                if(floorPositions.Find(x => x.Mycoords == neighborPosition) != null && floorPositions.Find(x => x.Mycoords == neighborPosition).MyhasObject == false && Random.Range(1,50) == 1){
                    //ebug.Log("NOT NULL");
                    floorPositions.Find(x => x.Mycoords == neighborPosition).MyhasObject  = true;
                    enemyPositions.Add(neighborPosition);
                }
            }
            
        }
        return enemyPositions;
    }
}
