using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEquipment : BaseStatItem {

    public enum EquipmentTypes
    {
        HEAD,
        TORSO,
        LEGS
    }

    private EquipmentTypes equipmentType;
    private int equipmentID;

    public EquipmentTypes EquipmentType { get; set; }
    public int AbilityID { get; set; }
}
