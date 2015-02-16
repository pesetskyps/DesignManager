using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomMenuPopulator : MonoBehaviour {

    public GameObject prefabButton;
    public Transform contentPanel;
    List<Room> rooms = new List<Room>();
    void Start() {
        Features[] features = { Features.GoodNeighbours, Features.SeaView };
        Bugs[] bugs = { Bugs.BadElectricity };
        rooms.Add(new Room(1, "Room1", 1200, 2, bugs, features));
        PopulateList();
    }

    public void PopulateList()
    {

        foreach (Transform item in contentPanel)
        {
            Destroy(item.gameObject);
        }

        foreach (var room in rooms)
        {
            GameObject newButton = Instantiate(prefabButton) as GameObject;
            RoomMenuButton sampleobj = newButton.GetComponent<RoomMenuButton>();

            //sampleobj.roomName = room.roomName;
            sampleobj.roomCost.text = room.roomCost.ToString();
            sampleobj.roomStarsImg.sprite = room.roomStarsImg;
            sampleobj.roomImg.sprite = room.roomImg;

            string features = null;
            string bugs = null;
            foreach (var feature in room.roomFeatures)
            {
                features += string.Format("- {0} \n", feature);
            }
            foreach (var bug in room.roomBugs)
            {
                bugs += string.Format("- {0} \n", bug);
            }
            sampleobj.roomBugs.text = bugs;
            sampleobj.roomFeatures.text = features;
            newButton.transform.SetParent(contentPanel, false);
            contentPanel.SetAsLastSibling();
        }
    }
}
