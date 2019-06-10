using UnityEngine;

namespace Game
{
    public class MultiDisplay : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (Display.displays.Length > 1)
                Display.displays[1].Activate();
        }
    }
}
