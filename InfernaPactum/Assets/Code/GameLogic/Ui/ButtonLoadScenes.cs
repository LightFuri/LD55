using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonLoadScenes : MonoBehaviour
{
    [SerializeField] private int _idScenes;

    private Button _nextScense;
    private LoadLevel loadLevel;

    private void Start()
    {
        _nextScense = GetComponent<Button>();
        loadLevel = FindObjectOfType<LoadLevel>();
        _nextScense.onClick.AddListener(Run);
    }


    public void Run()
    {
        loadLevel.Load(_idScenes);
    }
}
