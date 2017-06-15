using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BaseAthleteClass : BaseCharacterClass {

	public BaseAthleteClass()
    {
        CharacterClassName = "Athlete";
        CharacterClassDescription = "A competitor that has trained to physical perfection.";

        Health = 15;
        Attack = 15;
        Dodge = 10;
        Willpower = 8;
    }
}
