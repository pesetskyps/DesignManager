using UnityEngine;
using System.Collections;

public class Room1 : MonoBehaviour
{

    [HideInInspector]
    public string roomName;
    [HideInInspector]
    public int roomCost;
    [HideInInspector]
    public Bugs[] roomBugs;
    [HideInInspector]
    public Features[] roomFeatures;

    void Start()
    {
        roomName = "Room1";
        var gmRoom = GameManager.Instance.rooms.Find(r => r.roomName == roomName);
        if (gmRoom != null)
        {
            GameManager.Instance.currentRoom = gmRoom;
            roomFeatures = gmRoom.roomFeatures;
            roomBugs = gmRoom.roomBugs;
        }
    }
}
