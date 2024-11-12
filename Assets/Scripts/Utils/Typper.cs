using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class Typper : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float timeBetweenCharacters = 0.1f;
    public string originalText;

    private void Start() {
        textMeshPro.text = "";
    }

    [Button]
    public void StartType() {
        StartCoroutine(ShowText(originalText));
    }

    IEnumerator ShowText(string text) {
        foreach (char c in text) {
            textMeshPro.text += c;
            yield return new WaitForSeconds(timeBetweenCharacters);
        }
    }
}
