using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class TorchEnabled : MonoBehaviour
    {
        [SerializeField]
        private GameObject objectToEnable;
      

        private void OnEnable()
        {
            objectToEnable.SetActive(true);
        }
    }
}
