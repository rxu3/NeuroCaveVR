using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
    public class NodeClick : MonoBehaviour, IInputHandler
    {

        [Tooltip("Indicates whether the button is clickable or not.")]
        public bool IsEnabled = true;

        public event Action ButtonPressed;


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
               

                if (eventData.selectedObject.name == this.name)
                {
                    
                    this.transform.parent.GetComponent<SingleConnectome>().DrawEdges(int.Parse(this.name));
                }
            }
        }

    }
}
