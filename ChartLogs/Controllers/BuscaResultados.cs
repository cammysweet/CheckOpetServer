using ChartLogs.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace ChartLogs.Controllers
{
    public class BuscaResultados
    {
        private string caminhoTxtResultados = ConfigurationManager.AppSettings["caminhoTxtResultados"];

        public List<Resultado> SearchForResults()
        {
            List<Resultado> lista = new List<Resultado>();
            string[] linha;
            string[] partialLinha;
            string resultado;
            DateTime dia;

            List<string> objListString = new List<string>();
            String[] dataCSV;
            dataCSV = System.IO.File.ReadAllLines(caminhoTxtResultados + "LogTesteOpetServer.txt", Encoding.UTF8);

            if (dataCSV != null)
            {
                foreach (String n in dataCSV)
                {
                    objListString.Add(n);
                }
                
            }

            foreach(string n in objListString)
            {
                linha = n.Split('?');
                partialLinha = linha[1].Split('-');

                resultado = partialLinha[0];
                dia = Convert.ToDateTime(partialLinha[1]);
                Resultado resultObject = new Resultado {Result = resultado == "'S'" ? true : false, Dia = dia };
                lista.Add(resultObject);
            }

            return lista;
        }
    }
}