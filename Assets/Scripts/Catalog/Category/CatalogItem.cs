using UnityEngine;
using System.Collections;

public enum CatalogType
{
    DiningRoom,
    Kitchen,
    LivingRoom,
    BathRoom,
    BedRoom

}

public enum CatalogSubType
{
    Tables,
    Chairs,
    BookShelves,
    BathRoom,
    BedRoom
}

public class CatalogItem : MonoBehaviour {

    public string itemName;
    public int itemId;
    public string itemDescription;
    public Sprite itemIcon;
    public CatalogType itemCatalogType;
    public CatalogSubType itemCatalogSubType;

    public CatalogItem(string name, int id, string desc, CatalogType itemType, CatalogSubType itemSubType)
    {
        itemName = name;
        itemId = id;
        itemDescription = desc;
        itemCatalogType = itemType;
        itemCatalogSubType = itemSubType;
        itemIcon = Resources.Load<Sprite>("Catalog/" + name);
    }
}
