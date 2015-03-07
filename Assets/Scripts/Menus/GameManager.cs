using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Room> rooms = new List<Room>();
    public Dictionary<Bugs, Bug> bugs = new Dictionary<Bugs, Bug>();
    public Room currentRoom;
    void Awake()
    {
        rooms.Add(new Room(1, "Room1", 1200, 2, new Bugs[] { Bugs.BadElectricity, Bugs.Termites }, new Features[] { Features.GoodNeighbours, Features.SeaView }));
        rooms.Add(new Room(2, "Room2", 1200, 5, new Bugs[] { Bugs.BadElectricity }, new Features[] { Features.GoodNeighbours }));
        InitBugs();
    }

    private void InitBugs()
    {
        bugs.Add(Bugs.BadElectricity,
            new Bug("Bad Electricity", Bugs.BadElectricity,
            "Electricity Bugs may lead to the fire.\nSuch a bugs can low down the cost of the house.", 1200, 3200,
            "Bugs/BadElectricity/CheapCostToFix",
            "Bugs/BadElectricity/EliteCostToFix",
            "Images/BadElectricity",
            0.1f,
            60
            ));

        bugs.Add(Bugs.Termites, new Bug("Termites", Bugs.Termites,
            "Termites damage the wooden surfaces and can cause the wall holes.",
            1500, 2200,
            "Bugs/Termites/CheapCostToFix",
            "Bugs/Termites/EliteCostToFix",
            "Images/Termites",
            0.15f,
            1200
            ));
    }

    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>(); //GameObject.FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void ShowMenu(Menu menu)
    {
        MenuManager.Instance.ShowMenu(menu);
    }

    public void HideMenu(Menu menu)
    {
        MenuManager.Instance.HideMenu(menu);
    }
}

public class PlayerStats
{
    public Dictionary<string, Dictionary<Bug, float>> BugFixTime;
}
