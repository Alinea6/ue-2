using Stats;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _level;
    [SerializeField] private GameObject _loseScreen;
    private GameData _gameData;

    public void SetUpGameOverScreen()
    {
        _level.SetActive(false);
        _loseScreen.SetActive(true);
    }

    public void SetUpGameScreen()
    {
        _loseScreen.SetActive(false);
        _level.SetActive(true);
        _gameData = FindObjectOfType<GameData>();
        _gameData.NewGame();
    }
}
