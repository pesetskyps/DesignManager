using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BugMenuPopulator : MonoBehaviour
{
    public GameObject prefab;
    public Transform contentPanel;

    private GameObject newButton;
    private RoomCustomization roomCustomizationScript;
    // Use this for initialization
    void Awake()
    {
        BugToolTip.onBugFound += this.PopulateBugMenu;
        RoomCustomization.onRoomLoaded += this.CleanBugMenu;
    }

    // Update is called once per frame
    public void PopulateBugMenu(Bug bug)
    {
        var room = GameObject.FindGameObjectWithTag("Room");
        if (room != null)
        {
            roomCustomizationScript = room.GetComponent<RoomCustomization>();

            newButton = Instantiate(prefab) as GameObject;
            BugPanel sampleobj = newButton.GetComponent<BugPanel>();

            sampleobj.Description.text = bug.Description;
            sampleobj.Name.text = bug.Name;
            sampleobj.CheapCostToFixText.text = bug.CheapCostToFix.ToString();
            sampleobj.CheapCostToFixImage.sprite = Resources.Load<Sprite>(bug.CheapCostToFixImageResourcePath);
            sampleobj.CheapFixTimeMin.text = ConvertTimeToString(bug.CheapTimeToFixMin);
            sampleobj.CheapCostToFixButton.onClick.AddListener(() => StartBugFix(room.name, FixType.Cheap, bug.CheapTimeToFixMin, bug));
            sampleobj.EliteCostToFixText.text = bug.EliteCostToFix.ToString();
            sampleobj.EliteCostToFixImage.sprite = Resources.Load<Sprite>(bug.EliteCostToFixImageResourcePath);
            sampleobj.EliteFixTimeMin.text = ConvertTimeToString(bug.EliteTimeToFixMin);
            sampleobj.EliteCostToFixButton.onClick.AddListener(() => StartBugFix(room.name, FixType.Cheap, bug.EliteTimeToFixMin, bug));

            newButton.transform.SetParent(contentPanel, false);
            contentPanel.transform.SetAsLastSibling();

            var buttonTransformer = sampleobj.CheapCostToFixButton.GetComponent<BugButtonTransformer>();
            if (buttonTransformer != null)
            {
                buttonTransformer.Bug = bug;
            }

            buttonTransformer = sampleobj.EliteCostToFixButton.GetComponent<BugButtonTransformer>();
            if (buttonTransformer != null)
            {
                buttonTransformer.Bug = bug;
            }
        }
    }

    void StartBugFix(string roomName, FixType fixType, float timeToFix, Bug bug)
    {
        var startTime = DateTime.Now;
        var duration = TimeSpan.FromMinutes(timeToFix);
        var endTime = startTime + duration;
        BugFix bugFix = new BugFix(roomName, startTime, duration, endTime, fixType, bug);

        if (roomCustomizationScript != null)
        {
            roomCustomizationScript.AddBugToStartedBugFixes(bugFix);
        }
    }

    string ConvertTimeToString(float minutes)
    {
        TimeSpan span = TimeSpan.FromMinutes(minutes);
        return span.ToReadableString();
    }

    void CleanBugMenu()
    {
        foreach (Transform item in contentPanel)
        {
            Destroy(item.gameObject);
        }
    }
}
