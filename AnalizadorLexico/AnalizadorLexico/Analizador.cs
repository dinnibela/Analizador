using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico
{
    class Analizador
    {
        static private List<Token> listaErrores;
        static private List<Token> listaTokens;
        ArrayList tokens;
        ArrayList tipos;
        public Analizador()
        {
            listaTokens = new List<Token>();
            tokens = new ArrayList();
            tipos = new ArrayList();

            tokens.Add("Resultado");  //0
            tokens.Add("Graficar"); //1
            tokens.Add("Node"); //2
           
            tipos.Add("Valor");
            tipos.Add("Operador");
            tipos.Add("IZQ");
            tipos.Add("DER");

        }
      

            
        public int estado_token;
        public void addToken(string lexema, string idToken, int linea, int columna, int indice)
        {
            
            Token nuevo = new Token(lexema, idToken, linea, columna, indice);
            listaTokens.Add(nuevo);
        }
        public void addError(String lexema, String idToken, int linea, int columna)
        {
            Token errtok = new Token(lexema, idToken, linea, columna);
            // ErroresToken errtok = new ErroresToken(lexema, idToken, linea, columna);
            listaErrores.Add(errtok);
        }
        public bool Macht_enReser(string sente)
        {
            bool enco = false;
            for (int i = 0; i < tokens.Count; ++i)
            {
                if (sente.ToString() == tokens[i].ToString())
                {
                    enco = true;
                    estado_token = i;
                    return enco;
                }
                else { enco = false; }

            }
            return enco;
        }


        public void Analizador_cadena(String entrada)
        {
            int estado = 0;
            int columna = 0;
            int fila = 1;
            string lexema = "";
            char c;
            entrada = entrada + " ";
            
            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada[i];
                columna++;
               
                switch (estado)
                {
                    case 0:
                        if (char.IsLetter(c))
                        {
                            estado = 1;
                            lexema += c;
                        }
                        else if (Char.IsDigit(c))
                        {
                            estado = 2;
                            lexema += c;
                        }
                       
                        else if (c == '"')
                        {
                            estado = 4;
                            i--;
                            columna--;
                        }
                        else if (c == ',')
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        else if (c == ' ')
                        {
                            estado = 0;
                        }
                        else if (c == '\n')
                        {
                            columna = 0;
                            fila++;
                            estado = 0;
                        }
                        else if (c == '\r')
                        {
                            columna = 0;
                            fila++;
                            estado = 0;
                        }
                        else if (c == '{')
                        {
                            lexema += c;
                           
                            addToken(lexema, "llaveIzq", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '}')
                        {
                            lexema += c;
                            addToken(lexema, "llaveDer", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '(')
                        {
                            lexema += c;
                            addToken(lexema, "parIzq", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == ')')
                        {
                            lexema += c;
                            addToken(lexema, "parDer", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;
                            lexema = "";
                        }

                        else if (c == ';')
                        {
                            lexema += c;
                            addToken(lexema, "Punto y Coma", fila, columna, i - lexema.Length);
                            lexema = "";
                        }

                        else if (c == '<')
                        {
                            lexema += c;
                            addToken(lexema, "Menor", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '>')
                        {
                            lexema += c;
                            addToken(lexema, "Mayor", fila, columna, i - lexema.Length);
                            lexema = "";
                        }

                        else if (c == '.')
                        {
                            lexema += c;
                            addToken(lexema, "Punto", fila, columna, i - lexema.Length);
                            lexema = "";
                        }

                    

                        /*operadores mat*/
                        else if (c == '+')
                        {
                            lexema += c;
                            addToken(lexema, "Suma", fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '-')
                        {
                            lexema += c;
                            addToken(lexema, "Menos", fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            addToken(lexema, "Multiplicacion", fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '/')
                        {
                            lexema += c;
                            addToken(lexema, "Division", fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '=')
                        {
                            lexema += c;
                            addToken(lexema, "Igualdad", fila, columna, i);
                            lexema = "";
                        }



                        else
                        {
                            
                            estado = -99;
                            i--;
                            columna--;
                        }
                        break;
                    case 1:
                      
                        if (Char.IsLetterOrDigit(c) || c == '_')
                        {
                            lexema += c;
                            estado = 1;
                          
                        }
                        else
                        {
                            Boolean encontrado = false;
                            encontrado = Macht_enReser(lexema);
                            if (encontrado)
                            {
                             
                                addToken(lexema, "Reservada", fila, columna, i - lexema.Length);
                            }
                            else
                            {
                               
                                addToken(lexema, "Identificador", fila, columna, i - lexema.Length);
                              

                            }
                           
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 2:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        else if (c == '.')
                        {
                            estado = 8;
                            lexema += c;
                        }
                  
                        else
                        {
                            
                            addToken(lexema, "Digito", fila, columna, i - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        else
                        {
                            estado = -99;
                            i = i - 2;
                            columna = columna - 2;
                            lexema = "";
                        }
                        break;
                    case 4:
                        if (c == '"')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        break;
                    case 5:
                        if (c != '"')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        else
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        break;
                    case 6:
                        if (c == '"')
                        {
                            lexema += c;
                           
                            addToken(lexema, "Cadena", fila, columna, i - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;
                           
                            addToken(lexema, "Coma", fila, columna, i - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }

                        break;

                   
                    case 8:
                        if (Char.IsDigit(c))
                        {
                            estado = 9;
                            lexema += c;
                        }
                        else
                        {
                           
                            addError(lexema, "Se esperaba un digito [" + lexema + "]", fila, columna);
                            estado = 0;
                            lexema = "";
                        }
                        break;
                    case 9:
                        if (Char.IsDigit(c))
                        {
                            estado = 9;
                            lexema += c;
                        }
                        else
                        {
                           
                            addToken(lexema, "Digito", fila, columna, i - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }

                        break;
                   
                    case -99:
                        lexema += c;


                        addError(lexema, "Carácter Desconocido", fila, columna);

                        estado = 0;
                        lexema = "";
                        break;
                }
            }


        }


        public string generarLista()
        {
            string retorno="";
            for (int i = 0; i < listaTokens.Count; i++)
            {
                Token actual = listaTokens.ElementAt(i);
                retorno += "[Lexema:" + actual.getLexema() + ",IdToken: " + actual.getIdToken() + ",Linea: " + actual.getLinea() + "]" + Environment.NewLine;
            }
            return retorno;
        }





    }
}
