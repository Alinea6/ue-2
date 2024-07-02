using UnityEngine;

public class GameData : MonoBehaviour
{
    private int _coins = 0;
    private int _score = 0;
    private int _lvl = 1;

    public void AddCoin()
    {
        _coins++;
        _score++;
    }

    public void DoorOpen()
    {
        _score += 5;
        _lvl++;
    }

    public int GetCoins()
    {
        return _coins;
    }

    public int GetScore()
    {
        return _score;
    }
    
    public void NewGame()
    {
        _coins = 0;
        _score = 0;
        _lvl = 1;
    }
}