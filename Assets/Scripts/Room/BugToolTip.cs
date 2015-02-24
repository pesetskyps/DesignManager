using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BugToolTip : MonoBehaviour, IPointerEnterHandler
{
    public GameObject prefab;
    public Bugs bugType;
    
    private Menu tooltip;
    private bool PanelIsActive;
    private Bug bug;

    void Start()
    {
        var gameManager = GameManager.Instance;

        //if bug exists than set all the values for the tooltip
        if (gameManager.bugs.TryGetValue(bugType, out bug))
        {
            GameObject newButton = Instantiate(prefab) as GameObject;
            tooltipMenu sampleobj = newButton.GetComponent<tooltipMenu>();
            sampleobj.tooltipName.text = bug.Name;
            sampleobj.tooltipImage.sprite = Resources.Load<Sprite>(bug.ImageResourcePath);
            sampleobj.tooltipDescription.text = bug.Description;

            var _canvas = GameObject.FindGameObjectWithTag("Canvas");
            if (_canvas != null)
            {
                newButton.transform.SetParent(_canvas.transform, false);
                _canvas.transform.SetAsLastSibling();
            }

            tooltip = sampleobj.GetComponent<Menu>();
        }
    }

    void Update()
    {
        if (tooltip != null)
        {
            if (!PanelIsActive && !tooltip.IsHovered)
            {
                GameManager.Instance.HideMenu(tooltip);
            }
        }
    }

    IEnumerator SetActivePanel()
    {
        if (tooltip != null)
        {
            PanelIsActive = true;
            GameManager.Instance.ShowMenu(tooltip);
            yield return new WaitForSeconds(2f);
            PanelIsActive = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // StartCoroutine is used to give time to the user to hover over the tooltip itself. 
        StartCoroutine(SetActivePanel());
    }
}
