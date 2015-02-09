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

    public void PopulateList(CatalogItemType catalogItemType)
    {
       
        foreach (Transform item in contentPanel)
        {
            Destroy(item.gameObject);
        }
        List<CatalogItem> items = new List<CatalogItem>();
        Sprite[] icons = Resources.LoadAll<Sprite>("Catalog/" + catalogItemType.ToString());
        foreach (var item in icons)
        {


            items.Add(new CatalogItem(item.name, 1, item.name, CatalogSectionName.Null, catalogItemType, item));
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
