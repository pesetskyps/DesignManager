using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//[System.Serializable]
//public class CatalogDetailsPanelItem
//{
//    public string name;
//    public Sprite icon;
//    public bool isAvaliable;
//    public Button.ButtonClickedEvent buttonEvent;
//}

public class CatalogDetailsPanelPopulator : MonoBehaviour {

    public GameObject prefabButton;
    private List<CatalogItem> itemList = new List<CatalogItem>();
    public Transform contentPanel;
    void Start()
    {
        //test
        
        //PopulateList();
    }

    public void PopulateList(List<CatalogItem> itemList)
    {
        foreach (var item in itemList)
        {
            GameObject newButton = Instantiate(prefabButton) as GameObject;
            CatalogDetailsPanelButton sampleobj = newButton.GetComponent<CatalogDetailsPanelButton>();
            sampleobj.nameLabel.text = item.itemName;
            sampleobj.icon.sprite = item.itemIcon;
            newButton.transform.SetParent(contentPanel, false);

            contentPanel.SetAsLastSibling();
        }
    }

    public void Eeee()
    {
        Debug.Log("fddff");
    }
}
