using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MemuUIHandler : MonoBehaviour
{
    public InputField inputNameField;
    public Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        inputNameField.text = DataFlowManager.Instance.LastName;
        bestScoreText.text = $"Best Score : {DataFlowManager.Instance.BestName} : {DataFlowManager.Instance.BestScore}";
    }

    public void StartNew()
    {
        DataFlowManager.Instance.LastName = inputNameField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataFlowManager.Instance.SaveBestScore();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
