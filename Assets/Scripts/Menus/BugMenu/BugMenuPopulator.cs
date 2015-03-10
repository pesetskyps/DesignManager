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
    private BugFixer roomBugFixerScript;

    void Awake()
    {
        BugToolTip.onBugFound += this.PopulateBugMenu;
        RoomCustomization.onRoomLoaded += this.CleanBugMenu;
    }

    void OnEnable()
    {
        BugFixer roomBugFixerScript;
        var room = GameObject.FindGameObjectWithTag("Room");
        if (room != null)
        {
            roomBugFixerScript = room.GetComponent<BugFixer>();
            var foundugs = roomBugFixerScript.bbb;
            if (foundugs != null)
            {
                foreach (var bug in foundugs)
                {
                    PopulateBugMenu(bug);
                }
            }
        }



    }

    public void PopulateBugMenu(Bug bug)
    {
        var room = GameObject.FindGameObjectWithTag("Room");
        if (room != null)
        {
            roomCustomizationScript = room.GetComponent<RoomCustomization>();
            roomBugFixerScript = room.GetComponent<BugFixer>();
            if (roomBugFixerScript != null)
            {
                newButton = Instantiate(prefab) as GameObject;
                BugPanel sampleobj = newButton.GetComponent<BugPanel>();

                sampleobj.Description.text = bug.Description;
                sampleobj.Name.text = bug.Name;
                sampleobj.CheapCostToFixText.text = bug.CheapCostToFix.ToString();
                sampleobj.CheapCostToFixImage.sprite = Resources.Load<Sprite>(bug.CheapCostToFixImageResourcePath);
                sampleobj.CheapFixTimeMin.text = ConvertTimeToString(bug.CheapTimeToFixMin);
                sampleobj.CheapCostToFixButton.onClick.AddListener(() => roomBugFixerScript.StartBugFix(room.name, FixType.Cheap, bug.CheapTimeToFixMin, bug));
                sampleobj.CheapButtonTransformer.Bug = bug;

                sampleobj.EliteCostToFixText.text = bug.EliteCostToFix.ToString();
                sampleobj.EliteCostToFixImage.sprite = Resources.Load<Sprite>(bug.EliteCostToFixImageResourcePath);
                sampleobj.EliteFixTimeMin.text = ConvertTimeToString(bug.EliteTimeToFixMin);
                sampleobj.EliteCostToFixButton.onClick.AddListener(() => roomBugFixerScript.StartBugFix(room.name, FixType.Cheap, bug.EliteTimeToFixMin, bug));
                sampleobj.EliteButtonTransformer.Bug = bug;

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
