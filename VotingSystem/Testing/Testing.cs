using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DupecToolbox.Testing
{
    class Testing : MonoBehaviour
    {
        public void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 100000, 200000), "<size=26>Testing DupecToolbox Plugin</size>");
        }
    }
}
