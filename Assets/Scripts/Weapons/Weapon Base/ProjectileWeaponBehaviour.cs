using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    [SerializeField] private WeaponScriptableObject weaponData;

    protected Vector3 direction;
    [SerializeField] private float destroyAfterSeconds = 4f;

    private float initialZ;

    protected virtual void Awake()
    {
        initialZ = transform.eulerAngles.z;
    }

    protected virtual void Start()
    {

        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        if (dir.sqrMagnitude < Mathf.Epsilon)
            dir = transform.right;

        direction = dir.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + initialZ);
    }

    public WeaponScriptableObject GetWeaponData()
    {
        return weaponData;
    }
}