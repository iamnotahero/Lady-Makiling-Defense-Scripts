using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f; //22f
    [SerializeField] private GameObject particleOnHitPrefabVFX;

    private WeaponInfo weaponInfo;
    private Vector3 startPosition;

    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveDirection; 
    private float timer = 0f;
    [SerializeField] private float arrowDuration = 1f;

    private Vector2 direction;

    [SerializeField] private int life = 3;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Start() {
        startPosition = transform.position;
        moveDirection = Vector2.right.normalized;
        timer = 0;

    }
    public void Shoot(Vector2 direction){
        this.direction = direction;
        rb.velocity = this.direction * moveSpeed;
        transform.right =  this.direction;
    }
    private void Update()
    {
        //MoveProjectile();
        DetectDespawn();
        //DetectFireDistance();
    }

    public void UpdateWeaponInfo(WeaponInfo weaponInfo){
        this.weaponInfo = weaponInfo;
    }

/*
    private void OnTriggerEnter2D(Collider2D other) {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        Indestructible indestructible = other.gameObject.GetComponent<Indestructible>();
        TreeHealth treeHealth = other.gameObject.GetComponent<TreeHealth>();

        BounceViaRigidCollider(other);

        if (!other.isTrigger && (enemyHealth || treeHealth || indestructible)) {
            
            enemyHealth?.TakeDamage(weaponInfo.weaponDamage);
            //treeHealth?.TakeDamage(weaponInfo.weaponDamage);
            Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
            //Destroy(gameObject);
        }
    }
*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        Indestructible indestructible = collision.gameObject.GetComponent<Indestructible>();
        Destructible destructible = collision.gameObject.GetComponent<Destructible>();
        TreeHealth treeHealth = collision.gameObject.GetComponent<TreeHealth>();

        Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
        life--;
        if(life < 0){
            Destroy(gameObject);
            return;
        }
        if(destructible){
            destructible.DestroySelf();
            Shoot(direction);
        }
        if (enemyHealth){
            enemyHealth?.TakeDamage(weaponInfo.weaponDamage);
            Destroy(gameObject);     

        }else if(indestructible || treeHealth)
        {   
            BounceViaRigid(collision);
        }
        
    }


/*
    void OnCollisionStay2D(Collision2D collision)
    {
        Bounce(collision);
    }
*/
    private void Bounce(Collision2D collision){
            ContactPoint2D point = collision.contacts[0];
            Vector2 newDir = Vector2.zero;
            Vector2 curDire = this.transform.TransformDirection(moveDirection);
            newDir = Vector2.Reflect(curDire, point.normal);
            transform.rotation = Quaternion.FromToRotation(moveDirection, newDir);
    }

    private void BounceViaRigid(Collision2D collision){
            var firstContact = collision.contacts[0];
            Debug.Log(firstContact);
            Vector2 newDir = Vector2.Reflect(direction.normalized, firstContact.normal);
            Shoot(newDir.normalized);
    }


    private void BounceViaRigidCollider(Collider2D collision){
        ContactPoint2D[] contacts = new ContactPoint2D[10];
        int contactCount = collision.GetContacts(contacts);

        if (contactCount > 0){
            Vector2 contactNormal = contacts[0].normal;
            Vector2 newDir = Vector2.Reflect(direction.normalized, contactNormal);
            Shoot(newDir.normalized);
        }

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
