using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int iXPos;
    public int iYPos;
    //Check the index of where the symbol is in the array
    public int iHealth;
    public int iSpeed;
    public int iAttackDamage;
    public int iAttackSpeed;
    public int iAttackRange;

    public string sTeam;
    public string sSymbol;

    protected string sTypeName; //This will store the name of the type of unit

    public GameEngine GE;
    public GameObject ClosestUnit;

    public GameObject LifeBar;

    // Use this for initialization
    void Start () {
		
	}
	
    public void SetGameEngine()
    {
        GE = GameObject.Find("Game Engine").GetComponent<GameEngine>();
    }

    public void NewTarget()
    {
        List<GameObject> EUnits;

        if (sTeam == "Team 1")
        {
            EUnits = GE.Team2Units;
        }
        else 
        {
            EUnits = GE.Team1Units;
        }
        //else
        //{
        //    EnemyUnits = ;
        //}

        ClosestUnit = EUnits[0];

        foreach (GameObject EUnit in EUnits)
        {
            if (Vector2.Distance(transform.position, ClosestUnit.transform.position) > Vector2.Distance(transform.position, EUnit.transform.position))
            {
                ClosestUnit = EUnit;
            }
        }
    }

    public void UnitMove()
    {
        try
        {
            if (Vector2.Distance(transform.position, ClosestUnit.transform.position) > iAttackRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, ClosestUnit.transform.position, iSpeed * Time.deltaTime);
            }
        }
        catch
        {
            NewTarget();
        }
    }

    public void TakeDamage(int Damage)
    {
        iHealth = iHealth - Damage;
        LifeBar.transform.localScale = new Vector3(iHealth, 1, 1);

        if (iHealth <= 0)
        {
            Destroy(gameObject);
            if (sTeam == "Team 1")
            {
                GE.Team1Units.Remove(gameObject);
            }
            else
            {
                GE.Team2Units.Remove(gameObject);
            }
            NewTarget();
        }
    }

    public void OnCollisionStay2D(Collision2D UnitHit)
    {
        if (sTeam == "Team 1")
        {
            if (UnitHit.gameObject.tag == "TeamDos")
            {
                UnitHit.gameObject.GetComponent<Unit>().TakeDamage(iAttackDamage);
            }
        }
        else
        {
            if (UnitHit.gameObject.tag == "TeamUno")
            {
                UnitHit.gameObject.GetComponent<Unit>().TakeDamage(iAttackDamage);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
     
    public Unit()
    {
        //A constructor
    }

    public virtual void NewPostion()
    {
        //A method to move to a new position
    }

    public virtual void CombatHandling()
    {
        //A method to handle combat with another unit
    }

    public virtual void CheckAttackRange()
    {
        //A method to determine whether another unit is within attack range
    }

    public virtual void PosClosestUnit()
    {
        //A method to return position of the closest other unit to this unit
    }

    public virtual void Death()
    {
        //A method to handle the death/ destruction of this unit

        //if (tempUnit.Life <= 0)
        //{
        //    myUnits.Remove(tempUnit);
        //}                                     //Removes dead unit from the list
    }

    public virtual void ToString()  //https://www.dotnetperls.com/virtual
    {
        //Returns a neatly formatted string showing all the unit information
    }

    //public abstract void Save();

}
