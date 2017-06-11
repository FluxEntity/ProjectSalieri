using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour {

    public static int SaveExists { get; set; }
    public static string PlayerScene { get; set; }

    public static string PlayerName { get; set; }
    public static int PlayerLevel { get; set; }
    public static BaseCharacterClass PlayerClass { get; set; }
    public static int Health { get; set; }
    public static int Attack { get; set; }
    public static int Dodge { get; set; }
    public static int Willpower { get; set; }

}
