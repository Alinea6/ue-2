using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 10.0f;
        public Direction direction;
        private bool _grounded = false;
        [SerializeField] private float jumpPower = 20;
        [SerializeField] private float jumpTime = 0.2f;
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
        
        private void Update()
        {
            if (transform.position.y < -5)
            {
                KillPlayer();
            }
            
            if (Input.GetKey(KeyCode.W))
            {
                Move(0, 1);
                SetRotation(0);
                direction = Direction.UP;
            }
    
            if (Input.GetKey(KeyCode.S))
            {
                Move(0, -1);
                SetRotation(-180);
                direction = Direction.DOWN;
            }
    
            if (Input.GetKey(KeyCode.A))
            {
                Move(-1, 0);
                SetRotation(-90);
                direction = Direction.LEFT;
            }
    
            if (Input.GetKey(KeyCode.D))
            {
                Move(1, 0);
                SetRotation(90);
                direction = Direction.RIGHT;
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_grounded)
                {
                    StartCoroutine(Jump());
                }
            }
        }
        
        private void Move(float x, float z)
        {
            transform.position += new Vector3(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);
        }
        
        private void SetRotation(float rotation)
        {
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _grounded = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _grounded = false;
            }
        }
        
        private IEnumerator Jump()
        {
            var waitTime = jumpTime / 10;
            for (int i = 0; i < 10; i++)
            {
                transform.position += new Vector3(0, jumpPower / 2, 0);
                yield return new WaitForSeconds(waitTime);
            }
        }
        
        public enum Direction
        {
            LEFT, RIGHT, UP, DOWN
        }

        public void KillPlayer()
        {
            Destroy(gameObject);
            _gameManager.SetUpGameOverScreen();
        }

        public void CreatePlayer()
        {
            Instantiate(gameObject, new Vector3(-13.55f, 2.65f, 0f), new Quaternion());
        }
    }
}
