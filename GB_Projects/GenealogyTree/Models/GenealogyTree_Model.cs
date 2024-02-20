using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenealogyTree.Base;
using GenealogyTree.Views;

namespace GenealogyTree.Models
{

    internal class GenealogyTree_Model
    {
        GenealogyTree_View view = new GenealogyTree_View();

        public GenealogyTree_Model()
        {

        }

        internal Person CreatePerson()
        {
            
            view.Display("")
        }
    }
}
