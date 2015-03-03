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
    public List<BugFix> StartedBugFixes = new List<BugFix>();


    public delegate void RoomLoadedEventHandler();
    public static event RoomLoadedEventHandler onRoomLoaded;

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

        BugToolTip.onBugFound += AddBugToFoundBugs;
        BugButtonTransformer.onBugCanceled += RemoveBugFromStartedBugFixes;
    }

    public void AddBugToFoundBugs(Bug bug)
    {
        FoundBugs.Add(bug);

    }

    public void AddBugToStartedBugFixes(BugFix bugfix)
    {
        StartedBugFixes.Add(bugfix);
        //if (onBugFound != null)
        //    onBugFound();
    }

    public void RemoveBugFromStartedBugFixes(Bug bug)
    {
        var startedBugFix = StartedBugFixes.Find(b => b.Bug.Name == bug.Name);
        if (startedBugFix != null)
        {
            StartedBugFixes.Remove(startedBugFix);
        }
    }
}
