using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{   

    public static ProjectileScript Instance;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    
    private void Awake(){
        Instance = this;
    }
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;            //remove if dont want rotate to mouse
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;            //remove if dont want rotate to mouse
        transform.rotation = Quaternion.Euler(0,0,rot + 90);                //remove if dont want rotate to mouse
    }

    // Update is called once per frame
    [SerializeField] private GameObject tree;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2){
            //Instantiate(tree, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

    [SerializeField] private int damageAmount = 5;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.GetComponent<EnemyHealth>()){
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damageAmount);
        }
    }
}
