using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMapGenerator : MonoBehaviour
{
    [SerializeField] protected TilemapVisualizer tilemapVisualizer;
    [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;

    private float waitToLoadTime = 1f;

    public void GenerateMap(){
        tilemapVisualizer.Clear();
        RunProceduralGeneration();
    }
    private void Start()
    {   
        GenerateMap();
        //StartCoroutine(LoadSceneRoutine());
        
    }

    private IEnumerator LoadSceneRoutine(){
        while (waitToLoadTime >= 0){
            waitToLoadTime -= Time.deltaTime;;
            yield return null;
        }
        UIFade.Instance.FadeToClear();
    }

    protected abstract void RunProceduralGeneration();
}
