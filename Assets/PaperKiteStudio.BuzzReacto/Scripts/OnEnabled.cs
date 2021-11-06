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

            StartCoroutine(Wait());

            objectToEnable.SetActive(true);
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1f);
            objectToDisable.SetActive(false);
        }
    }
}
