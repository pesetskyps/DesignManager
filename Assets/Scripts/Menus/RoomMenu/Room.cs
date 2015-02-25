using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Bugs
{
    BadElectricity,
    Termites
}

public class Bug
{
    public string Description { get; set; }
    public string Name { get; set; }
    public int CheapCostToFix { get; set; }
    public int EliteCostToFix { get; set; }
    public string CheapCostToFixImageResourcePath { get; set; }
    public string EliteCostToFixImageResourcePath { get; set; }
    public string ImageResourcePath { get; set; }

    public Bug(string Name, string desc, int cheapfix, int elitefix, string cheapfixImagePath,
        string eliteCostToFixImageResourcePath, string imageResoursePath)
    {
        Description = desc;
        this.Name = Name;
        CheapCostToFix = cheapfix;
        EliteCostToFix = elitefix;
        CheapCostToFixImageResourcePath = cheapfixImagePath;
        EliteCostToFixImageResourcePath = eliteCostToFixImageResourcePath;
        ImageResourcePath = imageResoursePath;
    }
}

public enum Features
{
    SeaView,
    GoodNeighbours
}

public class Room
{

    public int roomId;
    public string roomName;
    public int roomCost;
    public Sprite roomStarsImg;
    public Sprite roomImg;
    public Bugs[] roomBugs;
    public Features[] roomFeatures;

    public Room(int roomId, string roomName, int roomCost, int roomStars, Bugs[] roomBugs, Features[] roomFeatures)
    {
        this.roomId = roomId;
        this.roomName = roomName;
        this.roomCost = roomCost;
        Sprite[] textures = Resources.LoadAll<Sprite>("Images/Stars");
        if ((roomStars-1) <= textures.Length)
        {
            this.roomStarsImg = textures[roomStars - 1];
        }
        //this.roomStarsImg = Resources.Load<Sprite>("Images/Stars_" + roomStars.ToString());
        this.roomImg = Resources.Load<Sprite>("Levels/Rooms/" + roomName + "/" + roomName);
        this.roomBugs = roomBugs;
        this.roomFeatures = roomFeatures;
    }
}