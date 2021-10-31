using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
using SimpleJSON;
using TMPro;

namespace PaperKiteStudios.BuzzReacto
{
    public class CutsceneText : MonoBehaviour
    {
        public TextMeshProUGUI text1;
        public TextMeshProUGUI text2;
        public TextMeshProUGUI text3;
        public TextMeshProUGUI text4;
        public TextMeshProUGUI text5;

        public string text1Text;
        public string text2Text;
        public string text3Text;
        public string text4Text;
        public string text5Text;

        private Initializer init;

        private void Awake()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
        }
        // Start is called before the first frame update
        void Start()
        {    
            text1.text = init.GetText(text1Text);
            text2.text = init.GetText(text2Text);
            text3.text = init.GetText(text3Text);
            text4.text = init.GetText(text4Text);
            text5.text = init.GetText(text5Text);
        }
    }
}
