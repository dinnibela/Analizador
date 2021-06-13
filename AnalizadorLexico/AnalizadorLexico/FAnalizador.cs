using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorLexico
{
    public partial class FAnalizador : Form
    {
        public FAnalizador()
        {
            InitializeComponent();
        }

        private void BAnalizar_Click(object sender, EventArgs e)
        {
            string texto;
            List<string> resultado = new List<string>();
            texto = TCodigo.Text;
            Analizador Analiza = new Analizador();
            Analiza.Analizador_cadena(texto);

           Tresult.Text= Analiza.generarLista();
           

        }
    }
}
