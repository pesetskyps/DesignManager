using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class test : MonoBehaviour, IPointerEnterHandler
{

    public GameObject prefab;

    GameObject panel;
    GameObject camera;

    void Start()
    {
        panel = GameObject.Find("Canvas");
        camera = GameObject.Find("Camera");
    }

    public void OnPointerEnter(PointerEventData data)
    {
        RectTransform panelRectTransform;
        RectTransform parentRectTransform;
        panelRectTransform = prefab.transform as RectTransform;
        parentRectTransform = panelRectTransform.parent as RectTransform;

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, data.position, camera.GetComponent<Camera>(), out localPointerPosition))
        {
            panelRectTransform.localPosition = localPointerPosition;
        }
    }
}
