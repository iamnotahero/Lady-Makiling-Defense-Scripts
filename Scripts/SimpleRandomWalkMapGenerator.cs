using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
public class SampleClass
{
    public Vector2Int Mycoords {get; set;}
    public bool MyhasObject {get; set;}
    public SampleClass (Vector2Int coords, bool hasObject){
        Mycoords = coords;
        MyhasObject = hasObject;

    }
}
public class SimpleRandomWalkMapGenerator : AbstractMapGenerator
{

    [SerializeField] protected SimpleRandomWalkSO randomWalkParameters;

    protected override void RunProceduralGeneration(){
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
        List<SampleClass> floorPositionList = new List<SampleClass>();
        
        foreach (var position in floorPositions){
          var cls = new SampleClass(position, false);
          floorPositionList.Add(cls);
        }

        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
        EnemyGenerator.CreateEnemy(floorPositionList,tilemapVisualizer);
        TreeGenerator.CreateTree(floorPositionList, tilemapVisualizer);
        ObjectGenerator.CreateObject(floorPositionList,tilemapVisualizer);
        foreach (var position in floorPositionList){
            //Debug.Log(position.Mycoords + "  " +  position.MyhasObject);
        };        
       
    }


    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position){
        var currectPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < randomWalkParameters.iterations; i++){
            var path = ProceduralTerrainGeneration.SimpleRandomWalk(currectPosition, randomWalkParameters.walkLength);
            floorPositions.UnionWith(path);
            if(randomWalkParameters.startRandomlyEachIteration){
                currectPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
            
        }
        return floorPositions;
    }


}
