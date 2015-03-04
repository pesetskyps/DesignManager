using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class BugToolTip : MonoBehaviour, IPointerEnterHandler
{
    public GameObject prefab;
    public Bugs bugType;

    private Menu tooltip;
    private bool PanelIsActive;
    private Bug bug;
    private GameObject newButton;
    private GameObject _canvas;
    private GameManager gameManager;
    private GameObject mainCamera;
    private GameObject tempCameraObj;
    private GameObject BugMenu;
    private Camera roomCamera;
    private MainCameraMove mainCameraMoveScript;
    private RoomCustomization roomCustomizationScript;
    public delegate void BugFoundEventHandler(Bug bug);
    public static event BugFoundEventHandler onBugFound;

    void Start()
    {
        gameManager = GameManager.Instance;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        BugMenu = GameObject.Find("BugMenu");

        if (mainCamera != null)
        {
            mainCameraMoveScript = mainCamera.GetComponent<MainCameraMove>();
        }


        BugToolTip.onBugFound += AddBugToRoomFoundBugs;
    }

    private void CreateTooltip(PointerEventData data)
    {
        newButton = Instantiate(prefab) as GameObject;

        tooltipMenu sampleobj = newButton.GetComponent<tooltipMenu>();
        sampleobj.tooltipName.text = bug.Name;
        sampleobj.tooltipImage.sprite = Resources.Load<Sprite>(bug.ImageResourcePath);
        sampleobj.tooltipDescription.text = bug.Description;

        if (BugMenu != null)
        {
            var bugMenuMenu = BugMenu.GetComponent<Menu>();
            if (bugMenuMenu != null)
            {
                sampleobj.tooltipDetailsButton.onClick.AddListener(() => gameManager.ShowMenu(bugMenuMenu));
            }
        }

        _canvas = GameObject.FindGameObjectWithTag("RoomCanvas");

        if (_canvas != null)
        {
            newButton.transform.SetParent(_canvas.transform, false);
            _canvas.transform.SetAsLastSibling();

            tempCameraObj = GameObject.FindGameObjectWithTag("TempCamera");
            //set position
            var tooltipRect = newButton.GetComponent<RectTransform>();
            var canvasRect = _canvas.GetComponent<RectTransform>();
            
            //without camera the position will be set to incorrect high values. So we need this check
            if (tempCameraObj != null)
            {
                roomCamera = tempCameraObj.GetComponent<Camera>();
                Vector2 localPointerPosition;
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    canvasRect, data.position, roomCamera, out localPointerPosition
                ))
                {
                    tooltipRect.localPosition = localPointerPosition;
                }
            }
        }

        tooltip = sampleobj.GetComponent<Menu>();
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

    IEnumerator SetActivePanel(PointerEventData eventData)
    {
        // if we don't enter edit mode in scene. This is done to exclude popup tooltip 
        // while moving the camera
        if (!mainCameraMoveScript.IsEditModeKeyPressed())
        {
            if (tooltip == null)
            {
                //if bug exists than set all the values for the tooltip
                if (gameManager.bugs.TryGetValue(bugType, out bug))
                {
                    CreateTooltip(eventData);
                    
                    if (onBugFound != null)
                        onBugFound(bug);
                }
            }

            if (tooltip != null)
            {
                PanelIsActive = true;
                GameManager.Instance.ShowMenu(tooltip);
                yield return new WaitForSeconds(2f);
                PanelIsActive = false;
            }
        }
    }

    private void AddBugToRoomFoundBugs(Bug bug)
    {
        var room = GameObject.FindGameObjectWithTag("Room");
        if (room != null)
        {
            roomCustomizationScript = room.GetComponent<RoomCustomization>();
        }

        if (roomCustomizationScript != null)
        {
            //roomCustomizationScript.AddBugToFoundBugs(bug);

        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        // StartCoroutine is used to give time to the user to hover over the tooltip itself. 
        StartCoroutine(SetActivePanel(data));
    }
}
