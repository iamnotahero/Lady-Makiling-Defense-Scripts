using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{

    private float waitToLoadTime = 1f;
    private GameObject player;
    void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Start()
    {
    }
    public void LoadAnotherGame(){

        
        UIFade.Instance.FadeToBlack();
        StartCoroutine(LoadSceneRoutine("Game"));
    }    

        private IEnumerator LoadSceneRoutine(string scene){
        while (waitToLoadTime >= 0){
            waitToLoadTime -= Time.deltaTime;;
            yield return null;
        }
        SceneManager.LoadScene(scene);
        player.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        GameObject.Find("UICanvas").gameObject.transform.Find("Active Inventory").gameObject.SetActive(true);
        
    }  
}
