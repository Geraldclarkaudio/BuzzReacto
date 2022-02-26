using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PaperKiteStudios.BuzzReacto
{
    public class InteractPromptText : MonoBehaviour
    {
        private Initializer init;

        public TextMeshProUGUI text;
        public string textDisplay;

        // Start is called before the first frame update
        void Awake()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
        }

        private void Start()
        {
            text.text = init.GetText(textDisplay);
        }


    }
}
