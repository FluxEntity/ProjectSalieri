using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer {

    private string playerName;
    private int playerLevel;
    private BaseCharacterClass playerClass;
    private int health;
    private int attack;
    private int dodge;
    private int willpower;

    public string PlayerName { get; set; }
    public int PlayerLevel { get; set; }
    public BaseCharacterClass PlayerClass { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Dodge { get; set; }
    public int Willpower { get; set; }
}
