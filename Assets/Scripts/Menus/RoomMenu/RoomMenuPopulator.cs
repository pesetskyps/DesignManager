using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomMenuPopulator : MonoBehaviour {

    public GameObject prefabButton;
    public Transform contentPanel;
    List<Room> rooms;
    void Start() {
        rooms = GameManager.Instance.rooms;
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
            sampleobj.roomName.text = room.roomName;
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
            var roomName = room.roomName;
            sampleobj.roombutton.onClick.AddListener(() => LoadRoomOnClick(roomName));

            newButton.transform.SetParent(contentPanel, false);
            contentPanel.SetAsLastSibling();
        }
    }

    public void LoadRoomOnClick(string roomname)
    {
        SaveRoomSettings();
        var room = GameManager.Instance.currentRoom;
        var roomobj = GameObject.Find(room.roomName);
        Destroy(roomobj);
        var newRoomPrefab = Resources.Load<GameObject>("Levels/Rooms/" + roomname + "/" + roomname);
        if (newRoomPrefab != null)
        {
            var newRoomGameObj = Instantiate(newRoomPrefab) as GameObject;
        }

    }

    private void SaveRoomSettings()
    {
        //throw new System.NotImplementedException();
    }
}
