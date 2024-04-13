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
        Load();
     
    }

    private void Load()
    {
        StartCoroutine(LoadSenceCor());
    }

    private IEnumerator LoadSenceCor()
    {
        yield return new WaitForSeconds(1f);
        _asyncOperation = SceneManager.LoadSceneAsync(_IDSence);

        while (!_asyncOperation.isDone)
        {
            float progress = _asyncOperation.progress / _dalay;
            _loadBar.value = progress;
            yield return 0;
        }
        gameObject.SetActive(false);
    }
}
