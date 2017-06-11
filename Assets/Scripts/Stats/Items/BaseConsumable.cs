using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConsumable {

    public enum ConsumableTypes
    {
        HEALTH,
        HUNGER,
        ATTACK,
        DODGE,
        WILLPOWER
    }
    private ConsumableTypes consumableType;
    private int consumableID;

    public ConsumableTypes ConsumableType { get; set; }
}
