using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatItem : BaseItem {

    private int health;
    private int attack;
    private int dodge;
    private int willpower;

    public int Health { get; set; }
    public int Attack { get; set; }
    public int Dodge { get; set; }
    public int Willpower { get; set; }
}
