using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace PaperKiteStudios.BuzzReacto
{
    public class TheEnd : MonoBehaviour
    {
        public int currentProgress;
        private void OnEnable()
        {
            LOLSDK.Instance.SubmitProgress(0, currentProgress, 8);
            LOLSDK.Instance.CompleteGame();
            
            Debug.Log("Game Ended");
        }
    }
}
