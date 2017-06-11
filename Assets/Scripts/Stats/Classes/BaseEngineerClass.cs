using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEngineerClass : BaseCharacterClass {

	public BaseEngineerClass()
    {
        CharacterClassName = "Engineer";
        CharacterClassDescription = "A manufacturer of the modern day's finest gear.";

        Health = 15;
        Attack = 8;
        Dodge = 10;
        Willpower = 15;
    }
}
