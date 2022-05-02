using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New shipData", menuName = "Ship Data", order = 51)]

public class ScriptableObjectShip : ScriptableObject

{
    public Sprite shipImage;
    public string pilotName;
    public string movementSpeed;
    public string rotationSpeed;
    public string health;
    public string ammo;
    public string shieldDuration;
}
