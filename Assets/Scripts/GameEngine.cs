using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{

    int iCameraSpeed = 5;
    GameObject camera;

    public GameObject Team1Melee;
    public GameObject Team2Melee;
    public GameObject Team1Ranged;
    public GameObject Team2Ranged;

    public bool bGameOver;

    public List<GameObject> Team1Units = new List<GameObject>();
    public List<GameObject> Team2Units = new List<GameObject>();

    //public GameObject prefabReference;

    float fSpawnSpeedMelee = 3f;
    float fSpawnSpeedRanged = 9f;

    void Start()
    {
        camera = GameObject.Find("Main Camera");

        InvokeRepeating("GenerateMeleeUnits", 0f, fSpawnSpeedMelee);
        InvokeRepeating("GenerateRangedUnits", 0f, fSpawnSpeedRanged);

        //When resources = 50, spawn new unit... but resources increase +10 every second...
        //so spawn every 5 seconds... decrease amount of resources back to 0 after it hits 50...
    }

    public void GenerateMeleeUnits()
    {
        if (!bGameOver)
        {
            //Team 1
            GameObject Team1 = (GameObject)Instantiate(Team1Melee);
            Team1.transform.position = new Vector3(-6, 2, 1);
            SpriteRenderer sprite = Team1.GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Units";
            Team1.GetComponent<MeleeUnit>().sTeam = "Team 1";
            Team1Units.Add(Team1);
        }

        if (!bGameOver)
        {
            //Team 2
            GameObject Team2 = (GameObject)Instantiate(Team2Melee);
            Team2.transform.position = new Vector3(6, -2, 1);
            SpriteRenderer sprite = Team2.GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Units";
            Team2.GetComponent<MeleeUnit>().sTeam = "Team 2";
            Team2Units.Add(Team2);
        }
    }

    public void GenerateRangedUnits()
    {
        if (!bGameOver)
        {
            //Team 1
            GameObject Team1 = (GameObject)Instantiate(Team1Ranged);
            Team1.transform.position = new Vector3(-6, 2, 1);
            SpriteRenderer sprite = Team1.GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Units";
            Team1.GetComponent<RangedUnit>().sTeam = "Team 1";
            Team1Units.Add(Team1);
        }

        if (!bGameOver)
        {
            //Team 2
            GameObject Team2 = (GameObject)Instantiate(Team2Ranged);
            Team2.transform.position = new Vector3(6, -2, 1);
            SpriteRenderer sprite = Team2.GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Units";
            Team2.GetComponent<RangedUnit>().sTeam = "Team 2";
            Team2Units.Add(Team2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            camera.transform.Translate(new Vector2(iCameraSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            camera.transform.Translate(new Vector2(-iCameraSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            camera.transform.Translate(new Vector2(0, iCameraSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            camera.transform.Translate(new Vector2(0, -iCameraSpeed * Time.deltaTime));
        }
    }
}
