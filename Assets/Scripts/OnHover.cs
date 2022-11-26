using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEngine.UI.Image image;

    private Color initialColor;
    // Start is called before the first frame update
    void Start()
    {
        if (image == null)
        {
            image = GetComponent<UnityEngine.UI.Image>();
        }
        initialColor = image.color;
        image.color = Color.clear;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = initialColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.clear;
    }
}
