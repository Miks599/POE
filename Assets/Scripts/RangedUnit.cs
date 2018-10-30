using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedUnit : Unit {

	// Use this for initialization
	void Start ()
    {
        SetGameEngine();

        iSpeed = 4;
        iHealth = 5;
        iAttackDamage = 1;
        iAttackSpeed = 2;
        iAttackRange = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
        UnitMove();
	}
}
