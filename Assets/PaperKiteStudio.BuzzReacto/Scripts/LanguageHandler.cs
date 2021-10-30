using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using LoLSDK;

public class LanguageHandler : MonoBehaviour
{
    JSONNode _langNode;
    string _langCode = "en";

    // Start is called before the first frame update
    void Start()
    {
        LOLSDK.Instance.LanguageDefsReceived += new LanguageDefsReceivedHandler(LanguageUpdate);
    }
    void StartGame(string startGameJSON)
    {
        if (string.IsNullOrEmpty(startGameJSON))
            return;

        JSONNode startGamePayload = JSON.Parse(startGameJSON);
        // Capture the language code from the start payload. Use this to switch fonts
        _langCode = startGamePayload["languageCode"];
    }
    void LanguageUpdate(string langJSON)
    {
        if (string.IsNullOrEmpty(langJSON))
            return;

        _langNode = JSON.Parse(langJSON);
    }
    public string GetText(string key)
    {
        string value = _langNode?[key];
        return value ?? "--missing--";
    }
}
