using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class SOPlayerData : ScriptableObject
{
    public int price;
    public bool unLock;
    public int Hp;
    public float Speed;
    public float SpeedRotation;
    
}
