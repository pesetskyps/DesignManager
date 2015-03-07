using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	private Animator _animator;
	private CanvasGroup _canvasGroup;

    private bool _isHovered;

	public bool IsOpen {
		get {return _animator.GetBool("IsOpen");}
		set {_animator.SetBool("IsOpen",value);}
	}

    public bool IsHovered
    {
        get { return _isHovered; }
        set { _isHovered = value; }
    }

	public void Awake() {
		_animator = GetComponent<Animator> ();
		_canvasGroup = GetComponent<CanvasGroup> ();

		var rect = GetComponent<RectTransform> ();
		//rect.offsetMax = rect.offsetMin = new Vector2 (0, 0);
	}

	public void Update(){

		if (!_animator.GetCurrentAnimatorStateInfo (0).IsName ("Open")) {
			_canvasGroup.blocksRaycasts = _canvasGroup.interactable = false;
			_canvasGroup.alpha = 0;
		} else {
			_canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;
			_canvasGroup.alpha = 1;
		}
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsHovered = false;
    }
}
