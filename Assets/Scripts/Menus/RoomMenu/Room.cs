﻿using UnityEngine;
using System.Collections;

public enum Bugs
{
    BadElectricity,
    Termites
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