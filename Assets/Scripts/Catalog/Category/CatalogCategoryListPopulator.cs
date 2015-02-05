using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CatalogListItem
{
    public string name;
    public Sprite icon;
    public bool isAvaliable;
    public Button.ButtonClickedEvent buttonEvent;
}


public class CatalogCategoryListPopulator : MonoBehaviour
{

    public GameObject prefabButton;
    public List<CatalogListItem> itemList;
    public Transform contentPanel;

    void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        foreach (var item in itemList)
        {
            GameObject newButton = Instantiate(prefabButton) as GameObject;
            CatalogCategoryListButton sampleobj = newButton.GetComponent<CatalogCategoryListButton>();
            sampleobj.nameLabel.text = item.name;
            sampleobj.icon.sprite = item.icon;
            sampleobj.button.interactable = item.isAvaliable;
            sampleobj.button.onClick = item.buttonEvent;
            newButton.transform.SetParent(contentPanel, false);

            contentPanel.SetAsLastSibling();
        }
    }

    public void Eeee()
    {
        List<CatalogItem> items = new List<CatalogItem>();
        items.Add(new CatalogItem("table", 1, "table", CatalogType.DiningRoom, CatalogSubType.Tables));
        CatalogDetailsPanelPopulator populator = new CatalogDetailsPanelPopulator();
        populator.PopulateList(items);
    }
}
