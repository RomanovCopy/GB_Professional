using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02_InterfacesAndGeneralizations
{
    internal interface IBits
    {
        bool GetBits ( int index );
        void SetBits (  bool value, int index );
    }
}
