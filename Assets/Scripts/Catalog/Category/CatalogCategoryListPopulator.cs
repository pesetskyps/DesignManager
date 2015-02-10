using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class CatalogCategoryListPopulator : MonoBehaviour
{

    public GameObject prefabButton;
    public Transform contentPanel;

    void Start()
    {
        CatalogItem.catalogRelationship.Add(CatalogSectionName.DiningRoom, new List<CatalogItemType>() { CatalogItemType.Chair, CatalogItemType.Clock, 
			CatalogItemType.CoffeeTable, CatalogItemType.Table, CatalogItemType.Bar, CatalogItemType.Mirror });
		CatalogItem.catalogRelationship.Add(CatalogSectionName.Kitchen, new List<CatalogItemType>() { CatalogItemType.Cupboard, CatalogItemType.Stool, CatalogItemType.Table });
        CleanCategoryListPanel();
        PopulateCatalogList(CatalogSectionName.Null);

    }

    void CleanCategoryListPanel()
    {
        foreach (Transform item in contentPanel)
        {
            Destroy(item.gameObject);
        }
    }

	public void PopulateCatalogList() {
		PopulateCatalogList (CatalogSectionName.Null);
	}

    void PopulateCatalogList(CatalogSectionName catalogSection)
    {
        List<CatalogItem> items = new List<CatalogItem>();
        CleanCategoryListPanel();
        if (catalogSection == CatalogSectionName.Null)
        {
            foreach (CatalogSectionName sectionName in CatalogItem.catalogRelationship.Keys)
            {
                Sprite icon = Resources.Load<Sprite>("SectionMenu/" + sectionName);
                items.Add(new CatalogItem(sectionName.ToString(), 1, sectionName.ToString(), sectionName, CatalogItemType.Null, icon));
            }
        }
        else
        {
            foreach (CatalogItemType itemType in CatalogItem.catalogRelationship[catalogSection])
            {
                Sprite icon = Resources.Load<Sprite>("SectionMenu/SubClass/" + itemType);
                items.Add(new CatalogItem(itemType.ToString(), 1, itemType.ToString(), CatalogSectionName.Null, itemType, icon));
            }
        }
        foreach (var catalogItem in items)
        {
            GameObject newButton = Instantiate(prefabButton) as GameObject;
            CatalogCategoryListButton sampleobj = newButton.GetComponent<CatalogCategoryListButton>();
            sampleobj.nameLabel.text = catalogItem.itemName;
            sampleobj.catalogType = catalogItem.catalogSectionName;
            sampleobj.icon.sprite = catalogItem.itemIcon;
            string captured = catalogItem.itemName;
            sampleobj.button.onClick.AddListener(() => GetCategoryDetails(captured));
            newButton.transform.SetParent(contentPanel, false);

            contentPanel.SetAsLastSibling();
        }
    }
    //CatalogType type
    public void GetCategoryDetails(string catalogSection)
    {
        CatalogSectionName section = CatalogSectionName.Null;
        CatalogItemType itemType = CatalogItemType.Null;
        try
        {
            itemType = (CatalogItemType)Enum.Parse(typeof(CatalogItemType), catalogSection);
        }
        catch (Exception)
        {
            Debug.Log("CatalogItemType not found. Checking whether it is more general CatalogSectionName...");
            try
            {
                section = (CatalogSectionName)Enum.Parse(typeof(CatalogSectionName), catalogSection);
            }
            catch (Exception)
            {
                Debug.Log("CatalogItemType not found. Maybe you specified the wrong Itemtype or categoryType?");
            }
        }
        if (itemType != CatalogItemType.Null)
        {
            GetComponent<CatalogDetailsPanelPopulator>().PopulateList(itemType);
        }
        else if (section != CatalogSectionName.Null)
        {
            PopulateCatalogList(section);
        }


    }
}
