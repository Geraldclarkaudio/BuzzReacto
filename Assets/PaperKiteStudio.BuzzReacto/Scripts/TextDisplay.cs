using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LoLSDK;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;

namespace PaperKiteStudios.BuzzReacto
{
    public class TextDisplay : MonoBehaviour
    {
        
        private Initializer init;
        //private Player player;
        public TextMeshProUGUI textComponent;
        public string[] lines;
        public float textSpeed;
        private int index;
        private void Start()
        {
           
            init = GameObject.Find("App").GetComponent<Initializer>();
            //player = GameObject.Find("Player").GetComponent<Player>();
            textComponent.text = init.GetText(lines[index]);
            StartDialogue();
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(textComponent.text == init.GetText(lines[index]))
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = init.GetText(lines[index]);
                }
            }
        }

        void StartDialogue()
        {
            index = 0;
            textComponent.text = init.GetText(lines[index]);
            //player.canMove = false;
            //StartCoroutine(TypeLine());
        }

        IEnumerator TypeLine()
        {
            foreach(char c in init.GetText(lines[index]).ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        void NextLine()
        {
            if(index < lines.Length - 1)
            {
                index++;
                textComponent.text = init.GetText(lines[index]);
               // StartCoroutine(TypeLine());
            }
            else
            {
              //  player.canMove = true;
                gameObject.SetActive(false);
            }
        }
    }
}