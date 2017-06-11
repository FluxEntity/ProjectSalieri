using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass {

    private string characterClassName;
    private string characterClassDescription;

    //Stats
    private int health;
    private int attack;
    private int dodge;
    private int willpower;

    //Constructors
    public string CharacterClassName { get;set; }
    public string CharacterClassDescription { get; set; }

    public int Health { get; set; }
    public int Attack { get; set; }
    public int Dodge { get; set; }
    public int Willpower { get; set; }
}
