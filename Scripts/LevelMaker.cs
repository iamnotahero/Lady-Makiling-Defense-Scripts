using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMaker : Singleton<LevelMaker>
{

    //[SerializeField] private GameObject enemy;
    //private GameObject enemyParent;
    //private float minX = -15;
    //private float maxX = 10;
    //private float minY = 0;
    // Start is called before the first frame update
    private float waitToLoadTime = 1f;
    private PlayerControls playerControls;
    [SerializeField] private GameObject player, UI, levelManager, managers;

    private bool canRun;
    
    protected override void Awake() {
        base.Awake();
        playerControls = new PlayerControls();
    }
    void Start()
    {   
        //canRun = true;
    }
    private void OnEnable() {
        playerControls.Enable();
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {   
        
        UIFade.Instance.FadeToClear();
        canRun = true;
        if(PlayerController.Instance){
            PlayerController.Instance.transform.position = new Vector3(0, 0, 0 );
        }
        /*
        if(CameraController.Instance){
            CameraController.Instance.SetPlayerCameraFollow();
        }
        */
    }
    



    void Update()
    {   
        GoToTitle();
        CheckIfWin();
    }

    public void CheckIfWin(){
        var enemyList = GameObject.Find("Enemies").transform;
        if(enemyList.childCount == 0 && canRun) {
            waitToLoadTime = 1f;
            canRun = false;
            UI.gameObject.transform.Find("Active Inventory").gameObject.SetActive(false);
                   
            UIFade.Instance.FadeToBlack();
            StartCoroutine(LoadNextLevelRoutine());
            
        }
    }
    public void GoToTitle(){
       if (playerControls.Menu.Keyboard.triggered && SceneManager.GetActiveScene().buildIndex != 0){
            waitToLoadTime = 1f;
            UIFade.Instance.FadeToBlack();    
            UI.gameObject.transform.Find("Active Inventory").gameObject.SetActive(false); 
            StartCoroutine(LoadTitleSceneRoutine());
       }  

       //DEBUG
    /*
       if (playerControls.DEBUG.ChangeScene.triggered && SceneManager.GetActiveScene().name != "Title Screen"){
            SceneManager.LoadScene("TEST");
            UIFade.Instance.FadeToClear();
            CameraController.Instance.SetPlayerCameraFollow();
       } 
    */
    }


    private IEnumerator LoadTitleSceneRoutine(){
        while (waitToLoadTime >= 0){
            waitToLoadTime -= Time.deltaTime;;
            yield return null;
        }
        //Destroy(player.gameObject);  
        //Destroy(UI.gameObject); 
        //Destroy(levelManager.gameObject);
        //Destroy(managers.gameObject);
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(UI, SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(levelManager, SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(managers, SceneManager.GetActiveScene());                  
        SceneManager.LoadScene(0);

    }  
    private IEnumerator LoadNextLevelRoutine(){
        while (waitToLoadTime >= 0){
            waitToLoadTime -= Time.deltaTime;;
            yield return null;
        }
                
        SceneManager.LoadScene("Victory Screen");
        player.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
       

    }      
}
