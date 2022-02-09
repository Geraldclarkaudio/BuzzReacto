﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto {
    public class BabyTree : MonoBehaviour
    {
        public bool canInteract = false;

        [SerializeField]
        private GameObject postPhotosynthBox;

        [SerializeField]
        private GameObject bubble;
        [SerializeField]
        private GameObject o2Particle;

        public GameObject photoSynthUI;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                canInteract = true;
                if (o2Particle.activeSelf == true)
                {
                    bubble.SetActive(false);
                }
                else if (o2Particle.activeSelf == false)
                {
                    bubble.SetActive(true);
                }
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                canInteract = false;
                bubble.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.hasPhotosynthesis == true)
            {
                if (canInteract == true && Input.GetKeyDown(KeyCode.E))
                {
                    postPhotosynthBox.SetActive(true);
                    o2Particle.SetActive(true);
                    bubble.SetActive(false);
                    //turn off photosynth in UI 
                    photoSynthUI.SetActive(false);
                }
            }
        }
    }
}
