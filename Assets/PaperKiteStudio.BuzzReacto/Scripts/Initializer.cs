using System.Collections;
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
        public float[] position;

        public PlayerData (Player player)
        {
            level = player.level;
            position = new float[3];

            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
        }
    }

    public class Initializer : MonoBehaviour
    {

        bool _init;
        WaitForSeconds _feedbackTimer = new WaitForSeconds(2);
        Coroutine _feedbackMethod;

        JSONNode _langNode;
        string _langCode = "en";

        [SerializeField, Header("State Data")] PlayerData playerData;
        


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
            LoadMockData();
#endif
          
            SceneManager.LoadScene("PressToStart");
            // Create the WebGL (or mock) object
            // This will all change in SDK V6 to be simplified and streamlined.

#if UNITY_EDITOR
            UnityEditor.EditorGUIUtility.PingObject(this);
#endif
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

            //TextDisplayUpdate();
        }

        public string GetText(string key)
        {
            string value = _langNode?[key];
            return value ?? "--missing--";
        }

        //void TextDisplayUpdate()
        //{
           
        //}

        void onload(PlayerData loadedPlayerData)
        {
            // Overrides serialized state data or continues with editor serialized values.
            if(loadedPlayerData != null)
            {
                playerData = loadedPlayerData;
            }
            //TextDisplayUpdate();
        }

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

        //YIKES

        void OnSaveResult(bool success)
        {
            if (!success)
            {
                Debug.LogWarning("Saving not successful");
                return;
            }
        }

        public void Save()
        {
            LOLSDK.Instance.SaveState(playerData);
            Debug.Log("Saved!");
        }
    }
}


