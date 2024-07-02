using TMPro;
using UnityEngine;

namespace Stats
{
    public class StatsScript : MonoBehaviour
    {
        private GameData _gameData;
        
        [SerializeField]
        private TextMeshProUGUI _scoreText;
        
        [SerializeField]
        private TextMeshProUGUI _coinsText;

        void Start()
        {
            _gameData = FindObjectOfType<GameData>();
        }
        
        // Update is called once per frame
        void Update()
        {
            _coinsText.text = $"Coins: {_gameData.GetCoins()}";
            _scoreText.text = $"Score: {_gameData.GetScore()}";
        }
    }
}
