using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Manages soul shards and buffs, should be singleton and persitant between scenes so as to not lose data
Buff info should be avilable to player but contained here for simplicity
*/

public class SoulManager : Singleton<SoulManager>
{
    int soulCount = 7;
    bool speedBuff;
    bool healthBuff;
    bool fireRateBuff;
    bool damageBuff;
    bool blockBuff;
    bool ignoreBuff;
}
