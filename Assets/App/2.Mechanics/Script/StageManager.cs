using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.App.Mechanics
{
    public class StageManager : MonoBehaviour
    {
        [SerializeField]
        private Stage[] stages;
        private int stage = 0;

        void Start()
        {
            Array.ForEach(stages, stage => stage.Close());
            stages[0].Open();
        }

        public void NextStage()
        {
            if (stage == stages.Length) return;
            stages[stage].Close();
            stage++;
            if (stage == stages.Length) return;
            stages[stage].Open();
        }
    }
}
