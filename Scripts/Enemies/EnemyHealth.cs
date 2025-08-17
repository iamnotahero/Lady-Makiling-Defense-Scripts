using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    private Animator myAnimator;
    private int currentHealth;
    private Knockback knockback;
    private Flash flash;
    private Rigidbody2D rb;
    [SerializeField] private Text text;
     private void Awake(){
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start(){
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        text.text = currentHealth.ToString();
        if (!myAnimator.GetBool("IsDead")){
             DetectDeath();
            knockback.GetKnockedBack(PlayerController.Instance.transform, 15f);
            //knockback.GetKnockedBack(ProjectileScript.Instance.transform, 15f);
            StartCoroutine(flash.FlashRoutine());
            
        }
    }
    public void DetectDeath(){
        if(currentHealth <= 0){
            //rb.velocity = Vector2.zero;
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            myAnimator.SetTrigger("IsDead");
            //Debug.Log(myAnimator.GetBool("IsDead"));
           
            //RunProceduralGeneration();
            //Destroy(gameObject);
        }
    }
    public void DestroySelf(){
        Destroy(gameObject);
    }

}
