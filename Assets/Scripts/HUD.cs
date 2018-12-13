using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
    public class HUD : MonoBehaviour, IInputHandler
    {

        [Tooltip("Indicates whether the button is clickable or not.")]
        public bool IsEnabled = true;

        public event Action ButtonPressed;

        public GameObject Anatomy;
        public GameObject Tsne;
        public GameObject Isomap;
        public GameObject Mds;
        public GameObject CAnatomy;
        public GameObject Embeddness;
        public GameObject RichClub;
        public GameObject EdgeOn;
        public GameObject EdgeOff;


        /// <summary>
        /// Press the button programmatically.
        /// </summary>

        public void Press()
        {
            if (IsEnabled)
            {
                ButtonPressed.RaiseEvent();
            }
        }

        void IInputHandler.OnInputDown(InputEventData eventData)
        {
            // Nothing.

        }

        void IInputHandler.OnInputUp(InputEventData eventData)
        {
            if (IsEnabled && eventData.PressType == InteractionSourcePressInfo.Select)
            {
                ButtonPressed.RaiseEvent();
                eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.

                if (eventData.selectedObject == Anatomy)
                {
                    this.transform.parent.GetComponentInChildren<SingleConnectome>()._representationType = SingleConnectome.representationTypes.Anatomy;
                    Anatomy.GetComponentInChildren<TextMesh>().color = Color.red;
                    Tsne.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    Mds.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    Isomap.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);

                }
                else if (eventData.selectedObject == Tsne)
                {
                    this.transform.parent.GetComponentInChildren<SingleConnectome>()._representationType = SingleConnectome.representationTypes.Tsne;
                    Anatomy.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    Tsne.GetComponentInChildren<TextMesh>().color = Color.red;
                    Mds.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    Isomap.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                }
                else if (eventData.selectedObject == Mds)
                {
                    this.transform.parent.GetComponentInChildren<SingleConnectome>()._representationType = SingleConnectome.representationTypes.MDS;
                    Anatomy.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    Tsne.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    Mds.GetComponentInChildren<TextMesh>().color = Color.red;
                    Isomap.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                }
                else if (eventData.selectedObject == Isomap)
                {
                    this.transform.parent.GetComponentInChildren<SingleConnectome>()._representationType = SingleConnectome.representationTypes.Isomap;
                    Anatomy.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    Tsne.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    Mds.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    Isomap.GetComponentInChildren<TextMesh>().color = Color.red;
                }

                if (eventData.selectedObject == CAnatomy)
                {
                    this.transform.parent.GetComponentInChildren<SingleConnectome>()._classificationType = SingleConnectome.classificationTypes.Anatomy;
                    CAnatomy.GetComponentInChildren<TextMesh>().color = Color.red;
                    Embeddness.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    RichClub.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);

                }
                else if (eventData.selectedObject == Embeddness)
                {
                    this.transform.parent.GetComponentInChildren<SingleConnectome>()._classificationType = SingleConnectome.classificationTypes.Embeddness;
                    CAnatomy.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    Embeddness.GetComponentInChildren<TextMesh>().color = Color.red;
                    RichClub.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                }
                else if (eventData.selectedObject == RichClub)
                {
                    this.transform.parent.GetComponentInChildren<SingleConnectome>()._classificationType = SingleConnectome.classificationTypes.RichClub;
                    CAnatomy.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    Embeddness.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    RichClub.GetComponentInChildren<TextMesh>().color = Color.red;
                }


                if (eventData.selectedObject == EdgeOn)
                {
                    this.transform.parent.GetComponentInChildren<BoxCollider>().enabled= false;
                    EdgeOn.GetComponentInChildren<TextMesh>().color = Color.red;
                    EdgeOff.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);


                }
                else if (eventData.selectedObject == EdgeOff)
                {
                    this.transform.parent.GetComponentInChildren<BoxCollider>().enabled = true;
                    EdgeOn.GetComponentInChildren<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
                    EdgeOff.GetComponentInChildren<TextMesh>().color = Color.red;

                }

            }
        }

    }
}
