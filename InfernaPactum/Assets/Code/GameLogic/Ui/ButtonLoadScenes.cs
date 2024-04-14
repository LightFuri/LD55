using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonLoadScene : MonoBehaviour
{
    [SerializeField] private int _idScene;

    private Button _nextScene;
    private LoadLevel loadLevel;

    private void Start()
    {
        _nextScene = GetComponent<Button>();
        loadLevel = FindObjectOfType<LoadLevel>();
        _nextScene.onClick.AddListener(Run);
    }


    public void Run()
    {
        loadLevel.Load(_idScene);
    }
}
