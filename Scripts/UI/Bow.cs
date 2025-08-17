using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnPoint;

    readonly int FIRE_HASH = Animator.StringToHash("Fire");

    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(FIRE_HASH);
        //Vector2 direction = transform.position;
        GameObject newArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, ActiveWeapon.Instance.transform.rotation);
  
        newArrow.GetComponent<Projectile>().UpdateWeaponInfo(weaponInfo);
        newArrow.GetComponent<Projectile>().Shoot(transform.right);
        //newArrow.GetComponent<Projectile>().Shoot(direction);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
 
    }
}
