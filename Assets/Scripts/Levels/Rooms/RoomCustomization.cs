using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(BugFixer))]
public class RoomCustomization : MonoBehaviour
{
    public string roomName;
    [HideInInspector]
    public int roomCost;
    [HideInInspector]
    public Bugs[] roomBugs;
    [HideInInspector]
    public Features[] roomFeatures;

    public delegate void RoomLoadedEventHandler();
    public static event RoomLoadedEventHandler onRoomLoaded;

    void OnEnable()
    {

        GameManager.Instance.Load();
    }

    void OnDisable()
    {
        BugFixer fixer = GetComponent<BugFixer>();
        GameManager.Instance.Save(fixer.FinishedBugFixes, fixer.StartedBugFixes, fixer.bbb);
    }
    void Start()
    {
        var gmRoom = GameManager.Instance.rooms.Find(r => r.roomName == roomName);
        if (gmRoom != null)
        {
            GameManager.Instance.currentRoom = gmRoom;
            roomFeatures = gmRoom.roomFeatures;
            roomBugs = gmRoom.roomBugs;
        }

        if (onRoomLoaded != null)
            onRoomLoaded();
    }
}
