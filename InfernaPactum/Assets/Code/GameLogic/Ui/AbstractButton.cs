using UnityEngine;
using UnityEngine.UI;

namespace Code.GameLogic.Ui
{
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButton : MonoBehaviour
    {
        private SoundController _soundHandler;
        protected Button _button;

        private void Start()
        {
           Init();
        }

        public virtual void Init()
        {
            _soundHandler = FindObjectOfType<SoundController>();
            _button= GetComponent<Button>();
            _button.onClick.AddListener(RunSound);
        }

        protected virtual void RunSound()
        {
            _soundHandler.PlayOne(ConstProvider.PATH_RESOURCES_NAME_BUTTON_CLICK);
        }


    }
}