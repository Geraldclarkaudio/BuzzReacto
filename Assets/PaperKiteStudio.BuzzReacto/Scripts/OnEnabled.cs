using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class OnEnabled : MonoBehaviour
    {
        [SerializeField]
        private GameObject objectToEnable;
        [SerializeField]
        private GameObject objectToDisable;

        private void OnEnable()
        {
           
            objectToDisable.SetActive(false);

            objectToEnable.SetActive(true);
        }
    }
}
