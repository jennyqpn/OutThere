using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New NPC", menuName = "CHARACTERS/NPC")]
public class NPC : ScriptableObject
{
    new public string name = "New NPC";
    public Sprite[] icon = new Sprite[3];
    public bool isDefault = false;
    public string[] dialogue = new string[9];
    public int friendship = 0;

    public virtual void Use()
    {
        Debug.Log("Using: " + name);
    }

}

