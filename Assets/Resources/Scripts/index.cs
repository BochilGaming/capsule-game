using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class index : MonoBehaviour
{
    public float ChangePosition = 5, Speed = 0.5f;
    private float LastChangeSpeed = 0;
    public bool IsPlaying = false;
    public Canvas GameOverCanvas;
    public Text TextScore;
    public int Score = 0;
    void Awake()
    {
        GameOverCanvas = Resources.Load<Canvas>("UI/GameOver");
    }
    void Start()
    {
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void FixedUpdate()
    {
        int LastUpdateSpeed = Mathf.RoundToInt(Time.time - LastChangeSpeed);
        if (LastUpdateSpeed != 0 && LastUpdateSpeed % 5 == 0)
        {
            Speed += 0.02f;
            LastChangeSpeed = Time.time;
        }
        Score += 1 * Mathf.RoundToInt(Speed);
        TextScore.text = "Score: " + Score; 
    }
    public void GameOver(GameObject OtherGameObject, GameObject Capsule)
    {
        Destroy(OtherGameObject);
        Destroy(Capsule);
        IsPlaying = false;
        Canvas GameOverCtx = Instantiate(GameOverCanvas, new Vector3(0, 0, 0), Quaternion.identity);
        // GameOverCtx.GetComponentInChildren<Button>().onClick.AddListener(ButtonHandler.OnClickGameOver);
    }
}
