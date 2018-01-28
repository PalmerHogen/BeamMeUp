namespace VRTK.UnityEventHelper
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WaveController : MonoBehaviour
    {

        private VRTK_Control_UnityEvents controlEvents;
        public WaveFormDraw userWave;
        public int index;
        public bool freq;
        public bool amp;

        // Use this for initialization
        void Start()
        {
            controlEvents = GetComponent<VRTK_Control_UnityEvents>();
            if (controlEvents == null)
            {
                controlEvents = gameObject.AddComponent<VRTK_Control_UnityEvents>();
            }

            if (userWave == null)
            {
                Debug.Log("No user wave form found");
                return;
            }

            controlEvents.OnValueChanged.AddListener(HandleChange);
        }

        private void HandleChange(object sender, Control3DEventArgs e)
        {
            if (freq)
                userWave.changeFreq(index, (int)e.value);
            if (amp)
                userWave.changeAmp(index, e.value);
        }
    }
}
