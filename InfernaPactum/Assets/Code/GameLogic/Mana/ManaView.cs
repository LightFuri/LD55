using System.Collections;
using TMPro;
using UnityEngine;

namespace Code.GameLogic.Mana
{
    public class ManaView : MonoBehaviour
    {
        private TMP_Text _text;
        private IBank _bank;


        private void Start()
        {
            _text = GetComponentInChildren<TMP_Text>();
            _bank = GetComponent<IBank>();
            _bank._VolumeManaCallBack += Render;
        }
        private void OnDisable()
        {
            _bank._VolumeManaCallBack -= Render;
        }


        private void Render(int volume)
        {
            _text.text = $"{volume} / 100";
        }
    }
}