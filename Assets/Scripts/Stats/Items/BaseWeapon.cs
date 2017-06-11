using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : BaseStatItem {

    public enum WeaponTypes {
        SWORD,
        STAFF,
        GUN
    }
    private WeaponTypes weaponType;
    private int weaponID;

    public WeaponTypes WeaponType { get; set; }
    public int AbilityID { get; set; }
}
