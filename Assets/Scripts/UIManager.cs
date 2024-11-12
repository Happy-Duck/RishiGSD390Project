using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Attributes: using serialize field to expose text object in editor
    [SerializeField] private Text scoreText;

    //Events: Subscribes or unsubscribes from the event based on whether the UI is enabled or disabled
    private void OnEnable()
    {
        BulletScript.ScoreUpdate += UpdateScoreUI;
    }
    private void OnDisable()
    {
        BulletScript.ScoreUpdate -= UpdateScoreUI;
    }

    //Events: updates score ui when score update event is invoked
    private void UpdateScoreUI(BulletScript bulletScript)
    {
        scoreText.text = "Score: " + GameManagerScript.Score;
    }
}
