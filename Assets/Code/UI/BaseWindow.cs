using UnityEngine;

public abstract class BaseWindow : MonoBehaviour
{
    public static TWindow Get<TWindow>() where TWindow : BaseWindow
    {
        return FindObjectOfType<TWindow>(true);
    }
        
    
    protected virtual void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Show(params object[] args)
    {
        gameObject.SetActive(true); //TODO: Поидеи объект включить сам себя не может если он неактивен. Починил этот момент.
        
        OnShow(args);
    }
    
    public void Hide()
    {
        OnHide();
        
        gameObject.SetActive(false);
    }

    protected abstract void OnShow(object[] args);
    protected abstract void OnHide();
}