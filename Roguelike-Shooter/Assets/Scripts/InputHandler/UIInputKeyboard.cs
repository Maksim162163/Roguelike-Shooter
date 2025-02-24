using UnityEngine;

namespace UIInputHandler
{
    public class UIInputKeyboard : UIProcessingDevice
    {
        public override bool IsPause()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                return true;
            }

            return false;
        }
    }
}
