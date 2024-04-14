using Code.GameLogic.Ui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetting : AbstractButton
{
    [SerializeField] private Canvas _playerCanvas;
    [SerializeField] private Canvas _setingCanvas;

    public override void Init()
    {
        base.Init();
        _button.onClick.AddListener(Run);
    }

    public void Run()
    {
        Invoke("Show", ConstProvider.WAITS_SOUND);
    }

    public void Show()
    {
        _playerCanvas.gameObject.SetActive(false);
        _setingCanvas.gameObject.SetActive(true);
    }
}
