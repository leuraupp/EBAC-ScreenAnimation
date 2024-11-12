using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

public enum ScreenType {
    Panel,
    Info_Panel,
    Shop
}

public class ScreenBase : MonoBehaviour
{
    public ScreenType screenType;
    public List<Transform> listOfObjects;
    public List<Typper> listOfTexts;
    public bool startHidden = false;

    [Header("Animation")]
    public float delayBetweenObjects = 0.05f;
    public float animationDuration = 0.3f;

    private void Start() {
        if (startHidden) {
            HideObjects();
        }
    }

    [Button]
    protected virtual void Show() {
        ShowObjects();
    }

    [Button]
    protected virtual void Hide() {
        HideObjects();
    }

    private void ShowObjects() {
        for (int i = 0; i < listOfObjects.Count; i++) {
            Transform obj = listOfObjects[i];
            obj.gameObject.SetActive(true);
            obj.DOScale(Vector3.zero, animationDuration).From().SetDelay(i * delayBetweenObjects);
        }

        Invoke(nameof(ShowTexts), delayBetweenObjects * listOfObjects.Count);
    }

    private void ShowTexts() {
        for (int i = 0; i < listOfTexts.Count; i++) {
            listOfTexts[i].StartType();
        }
    }

    private void ForceShowObjects() {
        listOfObjects.ForEach(obj => obj.gameObject.SetActive(true));
    }

    private void HideObjects() {
        listOfObjects.ForEach(obj => obj.gameObject.SetActive(false));
    }
}
