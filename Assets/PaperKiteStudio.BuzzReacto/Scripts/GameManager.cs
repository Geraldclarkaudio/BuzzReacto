using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("GameManager Is Null");
                }
                return _instance;
            }

        }

        public Player _player { get; set; }
       
        public bool hasWaterBottle { get; set; }

        public bool hasVinegar { get; set; }
        public bool hasBakingSoda { get; set; }
        public bool hasFuel { get; set; }
        public bool hasCarrot { get; set; }
        public bool hasCookedCarrot { get; set; }

        public bool hasPhotosynthesis { get; set; }

        public bool haspreMixedPotion { get; set; }
        public bool hasTreePotion { get; set; }
        public bool hasSolution2 { get; set; }

        public bool hasLava { get; set; }
        public bool hasWoodPlank { get; set; }

        private void Awake()
        {
            _instance = this;

            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (_player == null)
            {
                Debug.LogError("Player is Null");
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
