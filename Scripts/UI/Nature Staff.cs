using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureStaff : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject staffprojectilePrefab;
    [SerializeField] private Transform arrowSpawnPoint;

    readonly int AttackHash = Animator.StringToHash("Attack");

    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(AttackHash);


    }
    public void SpawnStaffProjectileAnimEvent() {
        GameObject newArrow = Instantiate(staffprojectilePrefab, arrowSpawnPoint.position, Quaternion.identity);
        newArrow.GetComponent<StaffProjectile>().UpdateWeaponInfo(weaponInfo);
    }
    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        else
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
