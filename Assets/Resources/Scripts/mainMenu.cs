using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class mainMenu : MonoBehaviour
{
    void Awake()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(this.PlayGame);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
