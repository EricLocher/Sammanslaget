using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class DragItem : MonoBehaviour, IEndDragHandler, IBeginDragHandler, IDragHandler
{
    public bool SetDragActive(bool state) => DragActive = state;

    protected bool DragActive = false;

    CanvasGroup canvasGroup;
    protected RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform.anchoredPosition = transform.parent.GetComponent<RectTransform>().anchoredPosition;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if(!DragActive) { return; }
        SoundManager.PlayRandomOneShot(new string[] { "drag1", "drag2"});
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!DragActive) { return; }
        rectTransform.anchoredPosition += eventData.delta / GameCanvas.GetCanvas().scaleFactor;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (!DragActive) { return; }
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = transform.parent.GetComponent<RectTransform>().anchoredPosition;
    }
}
