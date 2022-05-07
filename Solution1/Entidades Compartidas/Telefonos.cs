using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Telefonos
    {
        int numero;
        public int Numero
        {
            set { numero = value; }
            get { return numero; }
        }
        public Telefonos(int pTelefonos)
        {
            numero = pTelefonos;  
        }
    }
}
