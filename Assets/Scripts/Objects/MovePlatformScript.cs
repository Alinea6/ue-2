using UnityEngine;

namespace Objects
{
    public class MovePlatformScript : MonoBehaviour
    {
        private float _originalX;
        private bool _movingLeft = true;
        
        // Start is called before the first frame update
        void Start()
        {
            _originalX = transform.position.x;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < _originalX - 5 || transform.position.x > _originalX + 5)
            {
                _movingLeft = !_movingLeft;
            }

            float newX = !_movingLeft ? transform.position.x + 0.005f : transform.position.x - 0.005f;
            
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
