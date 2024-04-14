using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    private const float _dalay = 0.9f;

    private Slider _loadBar;
    private int _IDScene = 1;
    private AsyncOperation _asyncOperation;

    public void Init(int IDLevel)
    {
       _IDScene = IDLevel;
       _loadBar = FindObjectOfType<Slider>();
        Load(_IDScene);
     
    }

    public void Load(int id)
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
            _loadBar.value = 0;
        }
          
        StartCoroutine(LoadSceneCore(id));
    }

    private IEnumerator LoadSceneCore(int value)
    {
        yield return new WaitForSeconds(2f);
       

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
