using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PaperKiteStudios.BuzzReacto
{
    public class FloatUpSceneDialog : MonoBehaviour
    {

        public TextMeshProUGUI text1;
        public TextMeshProUGUI text2;

        public string text1Text;
        public string text2Text;

        private Initializer init;

        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();

            text1.text = init.GetText(text1Text);
            text2.text = init.GetText(text2Text);
        }


    }
}
