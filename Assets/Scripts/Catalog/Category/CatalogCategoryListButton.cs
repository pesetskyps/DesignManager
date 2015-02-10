using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CatalogCategoryListButton : MonoBehaviour//, IPointerDownHandler//, IPointerEnterHandler
{
    public Button button;
    public CatalogSectionName catalogType;
    public Text nameLabel;
    public Image icon;

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("hee");
    //}
}