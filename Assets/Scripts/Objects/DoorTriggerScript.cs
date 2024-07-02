using UnityEngine;

namespace Objects
{
    public class DoorTriggerScript : MonoBehaviour
    {
        private GameData _gameData;
        [SerializeField] private int _price = 0;
        [SerializeField] private GameObject _door;
        private bool _doorOpen = false;

        void Start()
        {
            _gameData = FindObjectOfType<GameData>();
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (_gameData.GetCoins() >= _price && !_doorOpen)
            {
                _gameData.DoorOpen();
                Destroy(_door.gameObject);
                _doorOpen = true;
            }
        }
    }
}
