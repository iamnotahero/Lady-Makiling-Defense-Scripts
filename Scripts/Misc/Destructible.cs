using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<DamageSource>() || other.gameObject.GetComponent<Projectile>() || other.gameObject.GetComponent<StaffProjectile>() || other.gameObject.GetComponent<NatureStaffProjectiles>()) {
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void DestroySelf(){
        Instantiate(destroyVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);        
    }
}
