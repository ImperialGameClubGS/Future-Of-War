using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace AssemblyCSharp.Assets.Scripts.Player
{

    public class PlayerUI : MonoBehaviour
    {
        
        public bool GameIsOver = false;
        public int HP = 125;
        public int Bullets = 100;
        private int _hp;
        private int _bullets;
        private SpawnManager _spawnManager;
        private PlayerController _player;
        //[SerializeField] private GameObject _gameOverScreen;
        //[SerializeField] private GameObject _bossFightPanel;


        private void OnEnable()
        {
            _player = GetComponentInParent<PlayerController>();
            _player.OnPlayerHealthValueChangedEvent += SetHP;
            //_spawnManager = GameObject.Find("SpawnPointsManager").GetComponent<SpawnManager>();
            //_bossFightPanel = GameObject.Find("BossFightPanel");
            //_bossFightPanel.SetActive(false);
        }

        private void OnDisable()
        {
            _player.OnPlayerHealthValueChangedEvent -= SetHP;
        }
        public void SetHP(int HP)
        {

            _hp = HP;

        }

        public void SetBullets(int Bullets)
        {
            _bullets = Bullets;
        }
        /*
        public void GameOver()
        {
            if (_gameOverScreen != null)
            {
                GameIsOver = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                _gameOverScreen.SetActive(true);

            }
        }
        
        private void CheckPlayerStats()
        {
            SetHP(HP);
            SetBullets(Bullets);
            if (_gameOverScreen != null)
            {
                _gameOverScreen.SetActive(false);
            }
            Time.timeScale = 1;
        }


        public void Retry()
        {
            if (_gameOverScreen != null)
            {
                _spawnManager.Resume = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        */
        public void Exit()
        {
            Application.Quit();
        }


        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.collider.CompareTag("BossArm"))
            {
                SetHP(50);
            }
        }

    }


}
