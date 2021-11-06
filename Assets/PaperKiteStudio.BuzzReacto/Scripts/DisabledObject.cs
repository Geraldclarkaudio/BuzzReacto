using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class DisabledObject : MonoBehaviour
    {
        [SerializeField]
        private GameObject sceneLoader;

        private void OnDisable()
        {
            sceneLoader.SetActive(true);
        }
    }
}
