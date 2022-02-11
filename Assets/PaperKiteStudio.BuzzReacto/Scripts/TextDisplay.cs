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
        private float textRate = 2.0f;
        private float canProceed = -1f;
        private Initializer init;
        private Player player;
        public TextMeshProUGUI textComponent;
        public string[] lines;
        public float textSpeed;
        private int index;

        [SerializeField]
        private GameObject[] icons;
        //0 = buzz, 1 = Sana, 2 = Pete, 2 = tree in gas scene

        [SerializeField]
        private GameObject woodDialogBox, torchDialogBox, peteDialogBox, carrotDialogBox, photosynthDialogBox, postPhotoDialogBox;

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

            if(Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if(textComponent.text == init.GetText(lines[index]))
                {
                    NextLine();
                    canProceed = Time.time + textRate;
                }
                else
                {
                    textComponent.text = init.GetText(lines[index]);
                }
            }

            #region GAS SCENE DIALOG
            //Intro Dialog for gas scene
            #region
            if (scene.name == "Gas")
            {
                if(woodDialogBox.activeSelf ==true)
                {
                    if (textComponent.text == init.GetText(lines[0]))
                    {
                        //buzz
                        icons[0].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[1]))
                    {
                        //sania
                        icons[0].SetActive(false);

                        icons[1].SetActive(true);

                    }
                    if (textComponent.text == init.GetText(lines[2]))
                    {
                        //tree
                        icons[1].SetActive(false);

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

                        icons[1].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[5]))
                    {
                        //tree
                        icons[1].SetActive(false);

                        icons[2].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[6]))
                    {
                        //tree
                        icons[2].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[7]))
                    {
                        //buzz
                        icons[2].SetActive(false);

                        icons[0].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[8]))
                    {
                        //tree
                        icons[0].SetActive(false);

                        icons[2].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[9]))
                    {
                        //tree
                        icons[2].SetActive(true);
                    }
                }
              
            }
            #endregion

            //collected Baking Soda
            #region
            if(scene.name == "Gas")
            {
                if(torchDialogBox.activeSelf == true)
                {
                    if (textComponent.text == init.GetText(lines[0]))
                    {
                        //buzz
                        icons[0].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[1]))
                    {
                        //buzz
                        icons[0].SetActive(true);
                    }
                }
            }
            #endregion  

            //Obtained Fuel For Ship
            #region
            if (scene.name == "Gas")
            {
                if (peteDialogBox.activeSelf == true)
                {
                    if (textComponent.text == init.GetText(lines[0]))
                    {
                        //buzz
                        icons[0].SetActive(true);
                    }
                }
            }
            #endregion
            #endregion

            #region CAVE DIALOG 
            //WOOD OBTAINED::Good
            #region
            if (scene.name == "Cave")
            {
                if(woodDialogBox.activeSelf == true)
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

            //PhotoSynethesis Dialog
            #region
            if (scene.name == "Cave")
            {
                if (photosynthDialogBox.activeSelf == true)
                {
                    if (textComponent.text == init.GetText(lines[0]))
                    {
                        //buzz
                        icons[0].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[1]))
                    {
                        //tree
                        icons[0].SetActive(false);
                        icons[2].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[2]))
                    {
                        //BUZZ
                        icons[2].SetActive(false);
                        icons[0].SetActive(true);

                    }
                    if (textComponent.text == init.GetText(lines[3]))
                    {
                        //tree
                        icons[0].SetActive(false);
                        icons[2].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[4]))
                    {
                        //buzz
                        icons[2].SetActive(false);
                        icons[0].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[5]))
                    {
                        //sania
                        icons[0].SetActive(false);
                        icons[1].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[6]))
                    {
                        //sania
                       
                        icons[1].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[7]))
                    {
                        //sania
                        icons[1].SetActive(true);
                    }
                }

                if(postPhotoDialogBox.activeSelf == true)
                {
                    if (textComponent.text == init.GetText(lines[0]))
                    {
                        icons[0].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[1]))
                    {
                        icons[0].SetActive(false);
                        icons[1].SetActive(true);
                    }
                }
            }

            #endregion

            ////TORCH DIALOG STUFF:: 
            #region
            if (scene.name == "Cave")
            {
                if (torchDialogBox.activeSelf == true)
                {
                    //buzz
                    icons[0].SetActive(true);
                }
            }
            #endregion

            //////CARROT OBTAINED::  
            #region
            if (scene.name == "Cave")
            {
                if (carrotDialogBox.activeSelf == true)
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

            //////MEET PETE:: 
            #region
            if (scene.name == "Cave")
            {
                if (peteDialogBox.activeSelf == true)
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
                        icons[1].SetActive(true);
                    }
                }
            }
            #endregion

            #endregion

            #region RABBIT RESCUED DIALOG

            if (scene.name == "Rabbit_Rescued")
            {
                if(woodDialogBox.activeSelf == true)
                {
                    icons[0].SetActive(true);
                }

                if(torchDialogBox.activeSelf == true)
                {
                    icons[0].SetActive(true);
                }
            }
            #endregion

            #region BUG SCENE DIALOG
            if(scene.name == "Bugs_Scene")
            {
                if (woodDialogBox.activeSelf == true)
                {
                    icons[0].SetActive(true);
                }

                if(torchDialogBox.activeSelf == true)
                {
                    if(textComponent.text == init.GetText(lines[0]))
                    {
                        icons[0].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[1]))
                    {
                        icons[0].SetActive(false);
                        icons[1].SetActive(true);
                    }
                    if (textComponent.text == init.GetText(lines[2]))
                    {
                        icons[1].SetActive(true);

                    }
                    if (textComponent.text == init.GetText(lines[3]))
                    {
                        icons[1].SetActive(true);
                    }
                }

                if (peteDialogBox.activeSelf == true)
                {
                    icons[0].SetActive(true);
                }

                if(carrotDialogBox.activeSelf == true)
                {
                    icons[0].SetActive(true);
                }
            }

            #endregion

            #region STIR SCENE DIALOG
            if (scene.name =="Stir")
            {
                if(woodDialogBox.activeSelf == true)
                {
                    icons[0].SetActive(true);
                }
                if(torchDialogBox.activeSelf == true)
                {
                    icons[0].SetActive(true);

                }
            }
            #endregion
            
            #region FINAL SCENE DIALOG
            if(scene.name == "Final_Scene")
            {
                if(woodDialogBox.activeSelf == true || torchDialogBox.activeSelf == true)
                {
                    icons[0].SetActive(true);
                }

                if(peteDialogBox.activeSelf == true)
                {
                    if(textComponent.text == init.GetText(lines[0]))
                    {
                        icons[0].SetActive(true);
                    }
                    if(textComponent.text == init.GetText(lines[1]))
                    {
                        icons[0].SetActive(false);
                        icons[1].SetActive(true);


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

            if(player != null)
            {
                player.canMove = false;
            }
           
        }

        void NextLine()
        {
            if(index < lines.Length - 1)
            {
                index++;
                textComponent.text = init.GetText(lines[index]);
                LOLSDK.Instance.SpeakText(lines[index]);
            }
            else
            {
                gameObject.SetActive(false);
                icons[0].SetActive(false);
                icons[1].SetActive(false);
                icons[2].SetActive(false);
                icons[3].SetActive(false);

               if(player!=null)
                {
                    player.canMove = true;
                }

            }
        }
    }
}