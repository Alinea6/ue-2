using TMPro;
using UnityEngine;

namespace Objects
{
    public class PriceTagScript : MonoBehaviour
    {
        private GameData _gameData;
        [SerializeField] private int _price = 0;
        [SerializeField] private TextMeshPro _priceText;
        
        void Start()
        {
            _gameData = FindObjectOfType<GameData>();
            Debug.Log(_gameData.GetCoins());
        }

        // Update is called once per frame
        void Update()
        {
            _priceText.text = $"{_gameData.GetCoins()}/{_price}";
        }
    }
}
