using UnityEngine;
using System.Collections;

public class BadElectricity : MonoBehaviour
{
    public GameObject tooltip;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000) && hit.transform.tag == "Bug")
        {
            tooltip.SetActive(true);
            tooltip.GetComponent<RectTransform>().localPosition = new Vector3(transform.position.x + 360, transform.position.y, transform.position.z);
        }
        else
        {
            tooltip.SetActive(false);
        }
    }
}
