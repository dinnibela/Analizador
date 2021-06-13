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
            texto = TCodigo.Text;
            Analizador Analiza = new Analizador();
            Analiza.Analizador_cadena(texto);

           Tresult.Text= Analiza.generarLista();
            //comen.Text = analiz.getRetorno();


            //lis_toks = new List<Token>();
            //lis_toks = analiz.getListaTokens();

            //for (int i = 0; i < lis_toks.Count; i++)
            //{
            //    Token actual = lis_toks.ElementAt(i);
            //    MessageBox.Show("[Lexema:" + actual.getLexema() + ",IdToken: " + actual.getIdToken() + ",Linea: " + actual.getLinea() + "]", "des");
            //}
        }
    }
}
