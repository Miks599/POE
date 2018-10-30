using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Unit {

	// Use this for initialization
	void Start ()
    {
        SetGameEngine();

        iSpeed = 2;
        iHealth = 10;
        iAttackDamage = 2;
        iAttackSpeed = 4;
        iAttackRange = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        UnitMove();
	}
}
