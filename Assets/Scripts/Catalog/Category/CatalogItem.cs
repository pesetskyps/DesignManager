using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CatalogSectionName
{
    Null,
    DiningRoom,
    Kitchen,
    LivingRoom,
    BathRoom,
    KidsRoom
}

public enum CatalogItemType
{
    Null,
    Armchair,
    Bed,
    BedsideTable,
    Bookcase,
    Bookshelf,
    Chair,
    ChestOfDrawers,
    Clock,
    CoatStand,
    CoffeeTable,
    Cupboard,
    Desk,
    DoubleBed,
    DressingTable,
    DrinksCabinet,
    FilingCabinet,
    Mirror,
    Piano,
    Sideboard,
    SingleBed,
    Sofa,
    SofaBed,
    Stool,
    Table,
    Wardrobe,
	Bar

}


public class CatalogItem {

    public string itemName;
    public int itemId;
    public string itemDescription;
    public Sprite itemIcon;
    public CatalogSectionName catalogSectionName;
    public CatalogItemType itemCatalogSubType;
    public  static Dictionary<CatalogSectionName, List<CatalogItemType>> catalogRelationship = new Dictionary<CatalogSectionName, List<CatalogItemType>>();

    public CatalogItem(string name, int id, string desc, CatalogSectionName sectionName, CatalogItemType itemSubType, Sprite icon)
    {
        itemName = name;
        itemId = id;
        itemDescription = desc;
        catalogSectionName = sectionName;
        itemCatalogSubType = itemSubType;
        //itemIcon = Resources.Load<Sprite>("Catalog/" + name);
        itemIcon = icon;
    }

    public List<CatalogItemType> GetCatalogRelationship(CatalogSectionName section) 
    {
        return catalogRelationship[section];
    }
}
