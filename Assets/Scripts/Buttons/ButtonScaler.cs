using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public float scaleMultiplier = 1.2f;
    public float animationDuration = 0.3f;

    private Vector3 originalScale;
    private Tween currentTween;

    private void Awake() {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Pointer Enter");
        currentTween = transform.DOScale(originalScale * scaleMultiplier, animationDuration);
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("Pointer Exit");
        currentTween.Kill();
        transform.DOScale(originalScale, animationDuration);
    }
}
