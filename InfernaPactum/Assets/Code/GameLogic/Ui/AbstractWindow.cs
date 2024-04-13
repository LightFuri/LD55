using UnityEngine;

public abstract class AbstractWindow : MonoBehaviour
{
    public virtual void Show() => gameObject.SetActive(true);
    public virtual void Hade() => gameObject.SetActive(false);

}
