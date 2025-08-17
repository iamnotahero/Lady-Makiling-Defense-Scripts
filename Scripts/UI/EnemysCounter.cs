using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemysCounter : MonoBehaviour
{
    private TextMeshProUGUI enemyText;

    private Transform enemyCount;

    void Awake()
    {
        enemyText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        enemyCount = GameObject.Find("Enemies").transform;
    }
 
    // Update is called once per frame
    void Update()
    {
        enemyText.text = ("Enemies LEFT: " + enemyCount.childCount.ToString());
    }
}
