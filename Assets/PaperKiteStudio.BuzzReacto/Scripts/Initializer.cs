﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using LoLSDK;
using SimpleJSON;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PaperKiteStudios.BuzzReacto
{
    [System.Serializable]
    public class PlayerData
    {
        public int level;
    }

    public class Initializer : MonoBehaviour
    {

        bool _init = false;
        WaitForSeconds _feedbackTimer = new WaitForSeconds(2);
        Coroutine _feedbackMethod;

        JSONNode _langNode;
        string _langCode = "en";

        [SerializeField, Header("State Data")] PlayerData playerData;
        [SerializeField] Button continueButton, newGameButton;
        [SerializeField] TextMeshProUGUI newGameText, continueText;



        void Awake()
        {
#if UNITY_EDITOR
            ILOLSDK sdk = new LoLSDK.MockWebGL();
#elif UNITY_WEBGL
			ILOLSDK sdk = new LoLSDK.WebGL();
#elif UNITY_IOS || UNITY_ANDROID
            ILOLSDK sdk = null; // TODO COMING SOON IN V6
#endif
            LOLSDK.Init(sdk, "com.PaperKiteStudios.BuzzReactoandtheTreeofLife");
            


            LOLSDK.Instance.StartGameReceived += new StartGameReceivedHandler(StartGame);
            LOLSDK.Instance.GameStateChanged += new GameStateChangedHandler(gameState => Debug.Log(gameState));
            LOLSDK.Instance.QuestionsReceived += new QuestionListReceivedHandler(questionList => Debug.Log(questionList));
            LOLSDK.Instance.LanguageDefsReceived += new LanguageDefsReceivedHandler(LanguageUpdate);
            //yikes
            LOLSDK.Instance.SaveResultReceived += OnSaveResult;
            LOLSDK.Instance.GameIsReady();
#if UNITY_EDITOR
            UnityEditor.EditorGUIUtility.PingObject(this);
            LoadMockData();
#endif
          
            
            // Create the WebGL (or mock) object
            // This will all change in SDK V6 to be simplified and streamlined.
            Helper.StateButtonInitialize<PlayerData>(newGameButton, continueButton, onload);

    
        }

        private void OnDestroy()
        {
#if UNITY_EDITOR
            if (!UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
                return;
#endif
            LOLSDK.Instance.SaveResultReceived -= OnSaveResult;
        }

        public void Save()
        {
            LOLSDK.Instance.SaveState(playerData);
        }

        void OnSaveResult(bool success)
        {
            if (!success)
            {
                Debug.LogWarning("Saving not successful");
                return;
            }
        }


            void StartGame(string startGameJSON)
        {
            if (string.IsNullOrEmpty(startGameJSON))
                return;

            JSONNode startGamePayload = JSON.Parse(startGameJSON);
           
            // Capture the language code from the start payload. Use this to switch fonts
            _langCode = startGamePayload["languageCode"];
        }

        public void LanguageUpdate(string langJSON)
        {
            if (string.IsNullOrEmpty(langJSON))
                return;

            _langNode = JSON.Parse(langJSON);

            TextDisplayUpdate();
        }

        public string GetText(string key)
        {
            string value = _langNode?[key];
            return value ?? "--missing--";
        }

        void TextDisplayUpdate()
        {
            newGameText.text = GetText("newGame");
            continueText.text = GetText("continueGame");
        }

        public void onload(PlayerData loadedPlayerData)
        {

            // Overrides serialized state data or continues with editor serialized values.
            if (loadedPlayerData != null)
            {
               playerData = loadedPlayerData;
            }

            if (playerData.level == 1)
            {
                loadedPlayerData.level = 1;
                SceneManager.LoadScene("Gas");
                Save();
            }
            if (playerData.level == 2)
            {
                loadedPlayerData.level = 2;
                SceneManager.LoadScene("Cave");
                Save();
            }
            if (playerData.level == 3)
            {
                loadedPlayerData.level = 3;
                SceneManager.LoadScene("Rabbit_Rescued");
                Save();
            }
            if (playerData.level == 4)
            {
                loadedPlayerData.level = 4;
                SceneManager.LoadScene("Bugs_Scene");
                Save();
            }
            if (playerData.level == 5)
            {
                loadedPlayerData.level = 5;
                SceneManager.LoadScene("Stir");
                Save();
            }


            TextDisplayUpdate();

            _init = true;
        }
#if UNITY_EDITOR
        private void LoadMockData()
        {
            // Load Dev Language File from StreamingAssets

            string startDataFilePath = Path.Combine(Application.streamingAssetsPath, "startGame.json");

            if (File.Exists(startDataFilePath))
            {
                string startDataAsJSON = File.ReadAllText(startDataFilePath);
                StartGame(startDataAsJSON);
            }

            // Load Dev Language File from StreamingAssets
            string langFilePath = Path.Combine(Application.streamingAssetsPath, "lang.json");
            if (File.Exists(langFilePath))
            {
                string langDataAsJson = File.ReadAllText(langFilePath);
                var lang = JSON.Parse(langDataAsJson)[_langCode];
                LanguageUpdate(lang.ToString());
            }
        }
#endif
        public void StartedGame()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void SceneChanged()
        {
            //I need to say if Active Scene is "gas" playerdata.level = 1 and so on and so forth.
            Scene scene = SceneManager.GetActiveScene();
            Debug.Log("Active Scene is " + scene.name);
            
            if(scene.name == "Gas")
            {
                playerData.level = 1;
            }
            
            if(scene.name == "Cave")
            {
                playerData.level = 2;
            }

            if(scene.name == "Rabbit_Rescued")
            {
                playerData.level = 3;
            }

            if(scene.name == "Bugs_Scene")
            {
                playerData.level = 4;
            }

            if(scene.name == "Stir")
            {
                playerData.level = 5;
            }    
            
            Save();
        }
    }
}


