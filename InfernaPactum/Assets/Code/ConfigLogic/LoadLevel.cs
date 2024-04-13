using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    private const float _dalay = 0.9f;

    private Slider _loadBar;
    private int _IDSence = 1;
    private AsyncOperation _asyncOperation;

    public void Init(int IDLevel)
    {
       _IDSence = IDLevel;
       _loadBar = FindObjectOfType<Slider>();
        Load(_IDSence);
     
    }

    private void Load(int value)
    {
        if(gameObject.activeSelf == false)
            gameObject.SetActive(true);
     
        StartCoroutine(LoadSenceCor(value));
    }

    private IEnumerator LoadSenceCor(int value)
    {
        yield return new WaitForSeconds(1f);
        _asyncOperation = SceneManager.LoadSceneAsync(value);

        while (!_asyncOperation.isDone)
        {
            float progress = _asyncOperation.progress / _dalay;
            _loadBar.value = progress;
            yield return 0;
        }
        gameObject.SetActive(false);
    }
}
