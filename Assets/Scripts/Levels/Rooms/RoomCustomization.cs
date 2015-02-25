using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomCustomization : MonoBehaviour
{
    public string roomName;
    [HideInInspector]
    public int roomCost;
    [HideInInspector]
    public Bugs[] roomBugs;
    [HideInInspector]
    public Features[] roomFeatures;

    public List<Bug> FoundBugs = new List<Bug>();
    public delegate void BugFoundEventHandler();
    public static event BugFoundEventHandler onBugFound;

    void Start()
    {
        var gmRoom = GameManager.Instance.rooms.Find(r => r.roomName == roomName);
        if (gmRoom != null)
        {
            GameManager.Instance.currentRoom = gmRoom;
            roomFeatures = gmRoom.roomFeatures;
            roomBugs = gmRoom.roomBugs;
        }
    }

    public void AddBugToFoundBugs(Bug bug){
        FoundBugs.Add(bug);
        if (onBugFound != null)
            onBugFound();
    }
}
