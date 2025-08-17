using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickPlay : MonoBehaviour
{   
    [SerializeField] private GameObject UITitle;
    private float waitToLoadTime = 1f;
    public void LoadGame(){

        SceneManager.MoveGameObjectToScene(UITitle, SceneManager.GetActiveScene());

        UIFade.Instance.FadeToBlack();
        StartCoroutine(LoadSceneRoutine("Game"));
    }  

        private IEnumerator LoadSceneRoutine(string scene){
        while (waitToLoadTime >= 0){
            waitToLoadTime -= Time.deltaTime;;
            yield return null;
        }
        SceneManager.LoadScene(scene);

    }  
}
