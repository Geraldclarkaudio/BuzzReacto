using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class OnDisabled : MonoBehaviour
    {
        [SerializeField]
        private GameObject objectToEnable;

        public void OnDisable()
        {
            objectToEnable.SetActive(true);
        }
    }
}
