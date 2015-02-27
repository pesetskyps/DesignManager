using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BugMenuPopulator : MonoBehaviour
{
    public GameObject prefab;
    public Transform contentPanel;
    private GameObject newButton;

    // Use this for initialization
    void Start()
    {
        RoomCustomization.onBugFound += this.PopulateBugMenu;
    }

    // Update is called once per frame
    void PopulateBugMenu()
    {
        CleanBugMenu();
        List<Bug> foundBugs = new List<Bug>();
        var room = GameObject.FindGameObjectWithTag("Room");
        if (room != null)
        {
            RoomCustomization roomCustomizationScript = room.GetComponent<RoomCustomization>();
            if (roomCustomizationScript != null)
            {
                foundBugs = roomCustomizationScript.FoundBugs;
            }
        }
        if (foundBugs != null)
        {
            foreach (var bug in foundBugs)
            {
                newButton = Instantiate(prefab) as GameObject;
                BugPanel sampleobj = newButton.GetComponent<BugPanel>();

                sampleobj.Description.text = bug.Description;
                sampleobj.Name.text = bug.Name;
                sampleobj.CheapCostToFixText.text = bug.CheapCostToFix.ToString();
                sampleobj.CheapCostToFixImage.sprite = Resources.Load<Sprite>(bug.CheapCostToFixImageResourcePath);
				sampleobj.CheapFixTime.text = bug.CheapTimeToFix.ToString();

                sampleobj.EliteCostToFixText.text = bug.EliteCostToFix.ToString();
                sampleobj.EliteCostToFixImage.sprite = Resources.Load<Sprite>(bug.EliteCostToFixImageResourcePath);
				sampleobj.EliteFixTime.text = bug.EliteTimeToFix.ToString();

                newButton.transform.SetParent(contentPanel, false);
                contentPanel.transform.SetAsLastSibling();
            }
        }

    }

    void CleanBugMenu()
    {
        foreach (Transform item in contentPanel)
        {
            Destroy(item.gameObject);
        }
    }
}
