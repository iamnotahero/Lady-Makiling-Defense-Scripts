using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureStaffTree : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    private WeaponInfo weaponInfo;
    
    private int RaysToShoot = 15;
    private float timer;


    public void UpdateWeaponInfo(WeaponInfo weaponInfo){
        this.weaponInfo = weaponInfo;
    }

    void Start()
    {
        float angle = 0;
        for (int i=0; i<RaysToShoot; i++) {
            float x = Mathf.Sin (angle);
            float y = Mathf.Cos (angle);
            angle += 2 * Mathf.PI / RaysToShoot;
            //Debug.Log(angle);
            Vector3 dir = new Vector3 (transform.position.x + x, transform.position.y + y, 0);
            //RaycastHit hit;
            //Debug.DrawLine (transform.position, dir, Color.red);
            float rot = Mathf.Atan2(y, x) * Mathf.Rad2Deg; 
            GameObject newArrow = Instantiate(arrow, transform.position, Quaternion.Euler(0,0,rot) );
            newArrow.GetComponent<NatureStaffProjectiles>().UpdateWeaponInfo(weaponInfo);
 
        }        
    }

    private void DespawnAtTimer(){
        timer += Time.deltaTime;
        if(timer > 2){
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        DespawnAtTimer();
    }
}
