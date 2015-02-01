using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragPanel_my : MonoBehaviour, IDragHandler,IPointerDownHandler
{
	private Vector2 PointerOffset;
	private RectTransform canvasRectTransform;
	private RectTransform panelRectTransform;
	void Awake ()
	{
		Canvas canvas = GetComponentInParent<Canvas> ();
		if (canvas != null) {
			canvasRectTransform = canvas.transform as RectTransform;
			panelRectTransform = transform as RectTransform;
		}
	}

	#region IPointerDownHandler implementation

	public void OnPointerDown (PointerEventData data)
	{
		panelRectTransform.SetAsLastSibling ();
		RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out PointerOffset);
	}

	#endregion

	#region IDragHandler implementation

		public void OnDrag (PointerEventData data)
		{
			if (panelRectTransform == null)
				return;
			Vector2 pointerPosition = ClampToWindow (data);
			Vector2 localPointerPosition;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
				canvasRectTransform, pointerPosition, data.pressEventCamera, out localPointerPosition
				)) {
			panelRectTransform.localPosition = localPointerPosition - PointerOffset;
			}
		}

	#endregion

	Vector2 ClampToWindow (PointerEventData data) {
		Vector2 rawPointerPosition = data.position;
		
		Vector3[] canvasCorners = new Vector3[4];
		canvasRectTransform.GetWorldCorners (canvasCorners);
		
		float clampedX = Mathf.Clamp (rawPointerPosition.x, canvasCorners[0].x, canvasCorners[2].x);
		float clampedY = Mathf.Clamp (rawPointerPosition.y, canvasCorners[0].y, canvasCorners[2].y);
		
		Vector2 newPointerPosition = new Vector2 (clampedX, clampedY);
		return newPointerPosition;
	}
}