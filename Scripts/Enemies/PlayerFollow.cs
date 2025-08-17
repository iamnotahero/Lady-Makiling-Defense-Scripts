using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{   
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void Update() {
        FaceMouse();
        Debug.Log(player.name);
    }

    private void FaceMouse() {
        Vector3 playerPosition = player.transform.position;
        //playerPosition = Camera.main.ScreenToWorldPoint(playerPosition);

        Vector2 direction = transform.position - playerPosition;

        transform.right = -direction;

        transform.Translate(Vector2.right * Time.deltaTime * 5); 
    }
}
