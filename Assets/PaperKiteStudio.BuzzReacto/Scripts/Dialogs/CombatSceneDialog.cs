using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PaperKiteStudios.BuzzReacto
{
    public class CombatSceneDialog : MonoBehaviour
    {
        public TextMeshProUGUI[] textComponent;
        public string[] textKey;
        private int i;

        private Initializer init;
        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();

            textComponent[i].text = init.GetText(textKey[i]);
            //textComponent[1].text = init.GetText(textKey[1]);
        }


    }
}
