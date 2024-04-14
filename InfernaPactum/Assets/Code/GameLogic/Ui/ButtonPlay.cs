using Code.GameLogic.Ui;
using UnityEngine;
using UnityEngine.UI;


public class ButtonPlay : AbstractButton
{
    [SerializeField] private int _idScene;
   
   
    private LoadLevel _loadLevel;

    public override void Init()
    {
        base.Init();
        _loadLevel = FindObjectOfType<LoadLevel>();
        _button.onClick.AddListener(RunLoading);
        
    }

    private void RunLoading()
    {
        Invoke("ShowLoad", ConstProvider.WAITS_SOUND);
    }

    private void ShowLoad()
    {
        _loadLevel.Load(_idScene);
    }
}
