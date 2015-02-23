using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BadElectricity : MonoBehaviour, IPointerEnterHandler
{
    public Menu tooltip;
    
    private bool PanelIsActive;

    void Update()
    {
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        
        //if (Physics.Raycast(ray, out hit, 1000) && hit.transform.tag == "Bug")
        //{
        //    StartCoroutine(SetActivePanel());
        //}
        //else if (!PanelIsActive && !tooltip.IsHovered)
        //{
        //    GameManager.HideMenu(tooltip);
        //}

        if (!PanelIsActive && !tooltip.IsHovered)
        {
            GameManager.Instance.HideMenu(tooltip);
        }
    }

    IEnumerator SetActivePanel()
    {
        PanelIsActive = true;
        GameManager.Instance.ShowMenu(tooltip);
        yield return new WaitForSeconds(2f);
        PanelIsActive = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
            StartCoroutine(SetActivePanel());        
    }
}
