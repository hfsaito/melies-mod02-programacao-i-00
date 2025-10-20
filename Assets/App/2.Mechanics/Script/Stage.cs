using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.App.Mechanics
{
    public class Stage : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] stageObjects;
        // // [SerializeField]
        // // private UnityEvent<int> OnStageChange;
        // private int stage = 0;

        // void Start()
        // {
        //     Array.ForEach(stageInstructions, instruction => instruction.SetActive(false));
        //     stageInstructions[0].SetActive(true);
        // }

        // public void NextStage()
        // {
        //     // stageInstructions[stage].SetActive(false);
        //     stage++;
        //     // stageInstructions[stage].SetActive(true);
        // }
        public void Open()
        {
            Array.ForEach(stageObjects, obj => obj.SetActive(true));
        }

        public void Close()
        {
            Array.ForEach(stageObjects, obj => obj.SetActive(false));
        }
    }
}
