using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public int iXPosition;
    public int iYPosition;
    public int iBuildingHealth;
    public string sTeam;
    public string sSymbol;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Building()
    {

    }

    //public abstract void Destruction(); //when building hp hits 0

    //public abstract void ToString();    //returns all building info

    //public abstract void Save();

}
