using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PaperKiteStudios.BuzzReacto
{
    public class DialogScroll : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        [SerializeField]
        private string currentText;
       

        private void Start()
        {

            ShowDialog(currentText);
        }


        public void ShowDialog(string text)
        {
            currentText = text;
            StartCoroutine(TextCoRoutine());
        }

        public void HideDialog()
        {
            StopAllCoroutines();
        }

        IEnumerator TextCoRoutine()
        {
            text.text = "";


            foreach (char l in currentText.ToCharArray())
            {
                text.text += l;
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(3.25f);
            HideDialog();

            yield return null;
        }
    }
}
