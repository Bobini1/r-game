using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEngine.UI.Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.clear;
    }
}
