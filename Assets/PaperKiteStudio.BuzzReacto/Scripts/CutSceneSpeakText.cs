using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LoLSDK;

namespace PaperKiteStudios.BuzzReacto
{
    public class CutSceneSpeakText : MonoBehaviour
    {
        private TextMeshProUGUI text;
     


        private Initializer init;
        public string key;

        private void Awake()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            text = GetComponent<TextMeshProUGUI>();
        }
        // Start is called before the first frame update
        void Start()
        {
            text.text = init.GetText(key);
            LOLSDK.Instance.SpeakText(key);
        }

    }
}
