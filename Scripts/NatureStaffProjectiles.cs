using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NatureStaffProjectiles : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f; //22f
    [SerializeField] private GameObject particleOnHitPrefabVFX;
    //[SerializeField] private Rigidbody2D rb;
    private WeaponInfo weaponInfo;
    private Vector3 startPosition;

    private Vector2 moveDirection; 
    private float timer = 0f;
    [SerializeField] private float arrowDuration = 1f;
    void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
    }
    private void Start() {
        startPosition = transform.position;
        moveDirection = Vector2.right.normalized;
        timer = 0;

    }
    private void Update()
    {
        
        DetectDespawn();
        //DetectFireDistance();
    }

    void FixedUpdate()
    {
        MoveProjectile();
    }

    public void UpdateWeaponInfo(WeaponInfo weaponInfo){
        this.weaponInfo = weaponInfo;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        Indestructible indestructible = collision.gameObject.GetComponent<Indestructible>();
        Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
        TreeHealth treeHealth = collision.gameObject.GetComponent<TreeHealth>();
        if (enemyHealth){
            enemyHealth?.TakeDamage(weaponInfo.weaponDamage);
            Bounce(collision);
            //Destroy(gameObject);             
            
        }else if(indestructible || treeHealth)
        {   
            Bounce(collision);
        }
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
       
    }

    private void Bounce(Collision2D collision){
            ContactPoint2D point = collision.contacts[0];
            Vector2 newDir = Vector2.zero;
            Vector2 curDire = this.transform.TransformDirection(moveDirection);
            newDir = Vector2.Reflect(curDire, point.normal);
            transform.rotation = Quaternion.FromToRotation(moveDirection, newDir);
    }

    
    private void DetectFireDistance() {
        if (Vector3.Distance(transform.position, startPosition) > weaponInfo.weaponRange) {
            Destroy(gameObject);
        }
    }
    
    private void DetectDespawn(){
        timer += Time.deltaTime;
        if( timer > arrowDuration){
            Destroy(gameObject);
        }
    }

    private void MoveProjectile()
    {
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed);  
    } 
}
