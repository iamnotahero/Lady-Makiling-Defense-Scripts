using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffProjectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX;

    [SerializeField] private GameObject tree , tree1;

    private WeaponInfo weaponInfo;
    private Vector3 startPosition;

    private float timer;

    private void Start() {
        startPosition = transform.position;
        LaserFaceMouse(); 
    }

    private void Update()
    {
        //timer += Time.deltaTime;
        MoveProjectile();
        DetectFireDistance();
        SpawnTreeAtDistance();
    }

    public void UpdateWeaponInfo(WeaponInfo weaponInfo){
        this.weaponInfo = weaponInfo;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        Indestructible indestructible = other.gameObject.GetComponent<Indestructible>();

        if (!other.isTrigger && (enemyHealth || indestructible)) {
            //enemyHealth?.TakeDamage(weaponInfo.weaponDamage);
            SpawnFightingTree();
            Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void DetectFireDistance() {
        if (Vector3.Distance(transform.position, startPosition) > weaponInfo.weaponRange) {
            Destroy(gameObject);
        }
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }

    private void SpawnFightingTree(){
        var treeList = new List<GameObject> { tree, tree1 };
        GameObject selectedTree = treeList[Random.Range(0,treeList.Count)];        
        GameObject treeToSpawn = Instantiate(selectedTree, transform.position, Quaternion.identity);
        treeToSpawn.GetComponent<NatureStaffTree>().UpdateWeaponInfo(weaponInfo);        
    }
    private void SpawnTreeAtDistance(){


        if (Vector3.Distance(transform.position, startPosition) > weaponInfo.weaponRange) {
            SpawnFightingTree();
            Destroy(gameObject);
        }                        
    }
    private void LaserFaceMouse(){
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = transform.position - mousePosition;
        transform.right = -direction;
    }
    
}
