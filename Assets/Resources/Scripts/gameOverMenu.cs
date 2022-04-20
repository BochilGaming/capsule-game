using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverMenu : MonoBehaviour
{
    void Awake()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(this.OnClickGameOver);
    }
    public void OnClickGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
