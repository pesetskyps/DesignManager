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

public class CatalogDetailsPanelPopulator : MonoBehaviour
{

    public GameObject prefabButton;
    public Transform contentPanel;

    public void PopulateList(CatalogSectionName catalogSection)
    {
       
        foreach (Transform item in contentPanel)
        {
            Destroy(item.gameObject);
        }
        List<CatalogItem> items = new List<CatalogItem>();
        Sprite[] icons = Resources.LoadAll<Sprite>("Catalogs/" + catalogSection.ToString());
        foreach (var item in icons)
        {


            items.Add(new CatalogItem(item.name, 1, "table", catalogSection, CatalogItemType.Table, item));
        }

        foreach (var item in items)
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
