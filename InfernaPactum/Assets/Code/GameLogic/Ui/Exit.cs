using Code.GameLogic.Ui;
using UnityEngine;

public class Exit : AbstractButton
{
    public override void Init()
    {
        base.Init();
        _button.onClick.AddListener(Run);
    }

    public void Run()
    {
        Invoke("ToLeave", ConstProvider.WAITS_SOUND);
    }

    public void ToLeave()
    {
        Application.Quit();
    }

}
