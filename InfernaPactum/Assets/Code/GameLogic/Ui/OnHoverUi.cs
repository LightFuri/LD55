using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHoverUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color _selectColor;
    [SerializeField] private Color _originalColor;
    

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      _image.color = _selectColor;
    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      _image.color = _originalColor;
    }
}
