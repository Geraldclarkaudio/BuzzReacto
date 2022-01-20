using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
using TMPro;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{
    public class GuidanceText : MonoBehaviour
    {

        private Initializer init;
        private Player player;
        public TextMeshProUGUI textComponent;
        public string[] lines;
        public float textSpeed;
        private int index;


        private void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            player = GameObject.Find("Player").GetComponent<Player>();
            textComponent.text = init.GetText(lines[index]);
            StartDialogue();
        }

        void StartDialogue()
        {
            index = 0;
            textComponent.text = init.GetText(lines[index]);
            LOLSDK.Instance.SpeakText(lines[index]);
            player.canMove = false;
        }

        void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                textComponent.text = init.GetText(lines[index]);
                LOLSDK.Instance.SpeakText(lines[index]);
            }
            else
            {
                gameObject.SetActive(false);

                player.canMove = true;

            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == init.GetText(lines[index]))
                {
                    NextLine();
                }
                else
                {
                    textComponent.text = init.GetText(lines[index]);
                }
            }
        }
    }
}
