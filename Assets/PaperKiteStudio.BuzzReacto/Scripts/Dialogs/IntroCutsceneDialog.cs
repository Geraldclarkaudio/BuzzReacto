﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PaperKiteStudios.BuzzReacto
{
    public class IntroCutsceneDialog : MonoBehaviour
    {
        public TextMeshProUGUI text1;
        public TextMeshProUGUI text2;
        public TextMeshProUGUI text3;
        public TextMeshProUGUI text4;

        public string text1Text;
        public string text2Text;
        public string text3Text;
        public string text4Text;

        private Initializer init;

        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();

            text1.text = init.GetText(text1Text);
            text2.text = init.GetText(text2Text);
            text3.text = init.GetText(text3Text);
            text4.text = init.GetText(text4Text);

        }

    }
}