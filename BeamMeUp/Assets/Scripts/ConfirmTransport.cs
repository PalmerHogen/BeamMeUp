namespace VRTK.UnityEventHelper
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ConfirmTransport : MonoBehaviour
    {

        private VRTK_Control_UnityEvents controlEvents;
        public WaveFormDraw userWave;
        public AudioClip[] sounds;
        private AudioSource soundSource;

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
            }

            soundSource = GetComponent<AudioSource>();
            if (soundSource == null)
            {
                Debug.Log("No sound source found");
            }

            controlEvents.OnValueChanged.AddListener(HandleChange);
        }

        private void HandleChange(object sender, Control3DEventArgs e)
        {
            Debug.Log(e.value.ToString());
            userWave.checkSuccess();
        }
    }
}
