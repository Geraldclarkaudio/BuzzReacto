using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace PaperKiteStudios.BuzzReacto
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField]
        private GameObject dialogueBox;

        private Player player;

        public int jellys;

        private AudioManager audioManager;

        [SerializeField]
        private GameObject cutsceneToActivate;

        private BabyTree tree;


        private void Start()
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

            if(SceneManager.GetActiveScene().name == "Cave")
            {
                tree = GameObject.Find("tree").GetComponent<BabyTree>();

            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                audioManager.PlayCollectedSound();

                Destroy(this.gameObject);

                ///GAS SCENE::::::::::::::::::::::::::::::::::::::::::
                if (gameObject.name == "Vinegar")
                {
                    GameManager.Instance.hasVinegar = true;             
                }

                if (gameObject.name == "Baking_Soda")
                {
                    GameManager.Instance.hasBakingSoda = true;
                    dialogueBox.SetActive(true);

                }
                //CAVE SCENE::::::::::::::::::::::::::::::::::::::
                if (gameObject.name == "Wood_Plank")
                {
                    GameManager.Instance.hasWoodPlank = true;
                    dialogueBox.SetActive(true);
                }
                if(gameObject.name == "Carrot")
                {
                    GameManager.Instance.hasCarrot = true;
                    dialogueBox.SetActive(true);
                }

                if (gameObject.name == "Water_Bottle")
                {
                    GameManager.Instance.hasWaterBottle = true;
                }

                if(gameObject.name == "Jelly(Clone)")
                {
                    Debug.Log("Obtained Jelly");
                    player.ObtainedJelly(jellys);
                }
                if(gameObject.name == "Lava")
                {
                    Debug.Log("Obtained Lava");
                    GameManager.Instance.hasLava = true;
                    tree.goHereArrow.SetActive(false);
                    cutsceneToActivate.SetActive(true);

                }
            }

        }
    }
}
