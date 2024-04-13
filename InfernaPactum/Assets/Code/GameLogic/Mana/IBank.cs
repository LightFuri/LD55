using System;

namespace Code.GameLogic.Mana
{
    public interface IBank
    {
        public event Action<int> _VolumeManaCallBack;
    }
}
