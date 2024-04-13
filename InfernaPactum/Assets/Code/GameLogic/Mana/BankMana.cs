using Code.GameLogic.Mana;
using System;
using UnityEngine;

public class BankMana : MonoBehaviour, IBank
{
    public event Action<int> _VolumeManaCallBack;

    public const int MAX_MANA = 100;
    public const int MIN_MANA = 0;

    public int ManaGain = 5;
    public int Mana = 0;


    private void Start()
    {
        InvokeRepeating("Tick", 0, 3);
    }

    private void Tick()
    {
        if (Mana+ ManaGain <= MAX_MANA)
        {
            Mana += ManaGain;
            _VolumeManaCallBack(Mana);
        }
           
    }

    public void Sell(int volume)
    {
        if (Mana - volume > MIN_MANA)
        {
            Mana -= volume;
        }
           
    }

}
