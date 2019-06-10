using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class Statistics : MonoBehaviour
    {
        /// <summary>
        /// Dictionary that holds all the Zones names and the distance travelled in meters
        /// </summary>
        private static Dictionary<string, float> _zonas;
        

        // Start is called before the first frame update
        void Start()
        {
            _zonas = new Dictionary<string, float>
            {
                { "Yellow", 0 },
                { "Green", 0 },
                {"Blue", 0 },
                {"Red", 0 }
            };
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void IncrementDistance(string area, float amount)
        {
            if (!_zonas.ContainsKey(area))
            {
                Debug.Log("Area nao existe");
                return;
            }

            //convert to meters
            amount *= 0.06761f;

            _zonas[area] += amount;
        }
    }
}
