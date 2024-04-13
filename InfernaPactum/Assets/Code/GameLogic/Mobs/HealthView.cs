using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Image _bar;

    private void Start()
    {
        _bar = GetComponentInChildren<Image>();
    }

    public void Render(float value)
    {
        _bar.fillAmount = value;
        
    }
    
        
}
