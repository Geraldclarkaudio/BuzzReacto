using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LoLSDK;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{
    public class TextDisplay : MonoBehaviour
    {
        
        private Initializer init;
        private Player player;
        public TextMeshProUGUI textComponent;
        public string[] lines;
        public float textSpeed;
        private int index;

        [SerializeField]
        private GameObject[] icons;
        //0 = buzz, 1 = Sana, 2 = Pete

        [SerializeField]
        private GameObject dialogBox;
        private void Start()
        {  
            init = GameObject.Find("App").GetComponent<Initializer>();
            player = GameObject.Find("Player").GetComponent<Player>();
            textComponent.text = init.GetText(lines[index]);
            StartDialogue();
        }

        private void Update()
        {
            Scene scene = SceneManager.GetActiveScene();

            if(Input.GetMouseButtonDown(0))
            {
                if(textComponent.text == init.GetText(lines[index]))
                {
                    NextLine();
                }
                else
                {
                    textComponent.text = init.GetText(lines[index]);
                }
            }
            //GAS SCENE DIALOG STUFF:: NNEEEEDSSS WOORRRKKK
            //#region
            //if (scene.name == "Gas")
            //{
            //    if (textComponent.text == init.GetText(lines[0]))
            //    {
            //        icon1.SetActive(true);
            //    }
            //    if (textComponent.text == init.GetText(lines[1]))
            //    {
            //        icon1.SetActive(false);
            //        icon2.SetActive(true);
            //    }
            //    if (textComponent.text == init.GetText(lines[2]))
            //    {
            //        icon2.SetActive(false);
            //        icon3.SetActive(true);
            //    }
            //    if (textComponent.text == init.GetText(lines[3]))
            //    {
            //        icon3.SetActive(false);
            //        icon1.SetActive(true);
            //    }
            //    if (textComponent.text == init.GetText(lines[4]))
            //    {
            //        icon1.SetActive(false);
            //        icon2.SetActive(true);
            //    }
            //    if (textComponent.text == init.GetText(lines[5]))
            //    {
            //        icon2.SetActive(false);
            //        icon3.SetActive(true);
            //    }
            //    if (textComponent.text == init.GetText(lines[6]))
            //    {
            //        icon3.SetActive(true);
            //    }
            //    if (textComponent.text == init.GetText(lines[7]))
            //    {
            //        icon3.SetActive(false);
            //        icon1.SetActive(true);
            //    }
            //    if (textComponent.text == init.GetText(lines[8]))
            //    {
            //        icon1.SetActive(false);
            //        icon3.SetActive(true);
            //    }
            //    if (textComponent.text == init.GetText(lines[9]))
            //    {
            //        icon3.SetActive(true);
            //    }
            //}
            //#endregion

            //Stuff is all messed up... 


            //WOOD OBTAINED::Good
            #region
            if(scene.name == "Cave")
            {
                if(dialogBox.activeSelf == true)
                {
                    if (textComponent.text == init.GetText(lines[0]))
                    {
                        //buzz
                        icons[0].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[1]))
                    {
                        //SANIA
                        icons[0].SetActive(false);
                        icons[1].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[2]))
                    {
                        //BUZZ
                        icons[1].SetActive(false);
                        icons[0].SetActive(true);

                    }
                    if (textComponent.text == init.GetText(lines[3]))
                    {
                        //SANIA
                        icons[0].SetActive(false);
                        icons[1].SetActive(true);
                    }
                }
            }
            #endregion


            //TORCH DIALOG STUFF:: Good
            #region
            if (scene.name == "Cave")
            {
                if (dialogBox.activeSelf == true)
                {
                    //buzz
                    icons[0].SetActive(true);
                }
            }
            #endregion

            ////CARROT OBTAINED:: Good 
            #region
            if (scene.name == "Cave")
            {
                if (dialogBox.activeSelf == true)
                {
                    if (textComponent.text == init.GetText(lines[0]))
                    {
                        //Sania
                        icons[1].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[1]))
                    {
                        //Buzz
                        icons[0].SetActive(true);
                        icons[1].SetActive(false);
                    }
                }
            }
            #endregion

            ////MEET PETE:: Good
            #region
            if (scene.name == "Cave")
            {
                if (dialogBox.activeSelf == true)
                {
                    if (textComponent.text == init.GetText(lines[0]))
                    {
                        //buzz
                        icons[0].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[1]))
                    {
                        //pete
                        icons[0].SetActive(false);
                        icons[2].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[2]))
                    {
                        //pete
                        icons[2].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[3]))
                    {
                        //buzz
                        icons[2].SetActive(false);
                        icons[0].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[4]))
                    {
                        //sania
                        icons[0].SetActive(false);
                        icons[2].SetActive(true);
                    }
                }
            }
            #endregion

        }

        void StartDialogue()
        {
            index = 0;
            textComponent.text = init.GetText(lines[index]);
            LOLSDK.Instance.SpeakText(lines[index]);
            player.canMove = false;
            //StartCoroutine(TypeLine());
        }

        void NextLine()
        {
            if(index < lines.Length - 1)
            {
                index++;
                textComponent.text = init.GetText(lines[index]);
                LOLSDK.Instance.SpeakText(lines[index]);
                // StartCoroutine(TypeLine());
            }
            else
            {
                player.canMove = true;
                gameObject.SetActive(false);
                icons[0].SetActive(false);
                icons[1].SetActive(false);
                icons[2].SetActive(false);
                icons[3].SetActive(false);
                //icon1.SetActive(false);
                //icon2.SetActive(false);
                //icon3.SetActive(false);
                //icon4.SetActive(false);
                //icon5.SetActive(false);

            }
        }
    }
}