using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 10;
    [SerializeField] private GameObject deathVFXPrefab;
    private Animator myAnimator;
    private int currentHealth;
    private Knockback knockback;
    private Flash flash;

    private Shake shake;
    private Rigidbody2D rb;
    [SerializeField] private Text text;
     private void Awake(){
        flash = GetComponent<Flash>();
        shake = GetComponent<Shake>();
        //knockback = GetComponent<Knockback>();
        //myAnimator = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();
    }
    private void Start(){
        currentHealth = startingHealth;
    }
    private void OnCollisionStay2D(Collision2D other) {
        EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();

        if (enemy) {
            TakeDamage(1);
            StartCoroutine(flash.FlashRoutine());
        }
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        text.text = currentHealth.ToString();
        DetectDeath();
        shake.StartShake();
        StartCoroutine(flash.FlashRoutine());        

    }
    public void DetectDeath(){
        if(currentHealth <= 0){
            
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            //myAnimator.SetTrigger("IsDead");
            //Debug.Log(myAnimator.GetBool("IsDead"));
           
            //RunProceduralGeneration();
            //Destroy(gameObject);
            DestroySelf();
        }
    }
    public void DestroySelf(){
        Destroy(gameObject);
    }
}
