using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TreeGenerator
{
  public static void CreateTree(List<SampleClass> floorPositions, TilemapVisualizer tilemapVisualizer){
        var basicTreePositions = FindSpotToPlace(floorPositions, Direction2D.cardinalDirectionList);
        foreach(var position in basicTreePositions){
            tilemapVisualizer.CreateTree(position);
        }
    }

    private static HashSet<Vector2Int> FindSpotToPlace(List<SampleClass> floorPositions, List<Vector2Int> directionsList)
    {
        HashSet<Vector2Int> treePositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions){
            //Debug.Log(position);

            foreach (var direction in directionsList){
                var neighborPosition = position.Mycoords + direction;
                if(floorPositions.Find(x => x.Mycoords == neighborPosition) != null && floorPositions.Find(x => x.Mycoords == neighborPosition).MyhasObject == false && Random.Range(1,100) == 1){
                    floorPositions.Find(x => x.Mycoords == neighborPosition).MyhasObject  = true;
                    treePositions.Add(neighborPosition);
                }
                //var cls = new SampleClass(neighborPosition, floorPositions.Find(x => x.Mycoords == neighborPosition).MyhasObject);
                //Debug.Log(floorPositions.Find(x => x.Mycoords == neighborPosition).Mycoords);
                if(floorPositions.Contains(new SampleClass(new Vector2Int(0,0), false))){
                    
                    
                    
                    if (1 == 1 ){
                        //objectPositions.Add(neighborPosition);
                        //floorPositions.Find(x => x.Mycoords == neighborPosition).MyhasObject = true;
                    }
                    
                }
            }        

            /*
            foreach (var direction in directionsList){
                var neighborPosition = position.Mycoords + direction;
                var cls = new SampleClass(neighborPosition, position.MyhasObject);
                Debug.Log(cls.MyhasObject);
                if(cls.MyhasObject == false){
                    
                    if (Random.Range(1,100) == 1 ){
                        treePositions.Add(neighborPosition);
                        position.MyhasObject = true;
                    }
                }
            }
             */
        }
       
        return treePositions;
    }
}
