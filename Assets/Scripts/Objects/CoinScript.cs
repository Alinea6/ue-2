using UnityEngine;

namespace Objects
{
    public class CoinScript : MonoBehaviour
    {
        private GameData _gameData;

        void Start()
        {
            _gameData = FindObjectOfType<GameData>();
        }
    
        private void OnTriggerEnter(Collider other)
        {
            _gameData.AddCoin();
            Destroy(gameObject);
        }
    }
}
