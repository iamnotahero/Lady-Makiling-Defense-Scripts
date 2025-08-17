using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    
    private TextMeshProUGUI scoreText;

    private Transform treesCount;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        treesCount = GameObject.Find("Trees").transform;
    }
    void OnEnable()
    {
        
    }
    private void Update()
    {
        scoreText.text = ("TREES LEFT: " + treesCount.childCount.ToString());
    }
}
