
using Microsoft.VisualBasic.CompilerServices;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CrawlerConsultaRAB.Utils;

namespace CrawlerConsultaRAB
{
    private Utils _utils = new Utils();

    public class Catcher
    {
        public List<Registro> GetData(HtmlDocument html)
        {
            List<Registro> registros = new List<Registro>();
            HtmlNodeCollection nodesData = html.DocumentNode.SelectNodes("//div[contains(@class, 'retorno-pesquisa')]/table/tbody/tr");

            foreach (HtmlNode node in nodesData)
            {
                Registro registro = new Registro();

                HtmlDocument nodeHtmlDoc = _utils.ParseToHtmlDocument(node);

                string indice = nodeHtmlDoc.DocumentNode.SelectSingleNode("th/text()");
                string texto = System.Empty;
                
                if(indice.Contains("Motivos(s)"))
                {
                    var motivos = nodeHtmlDoc.DocumentNode.SelectNodes("td/br");

                    if(motivos != null)
                    {
                        foreach (var txt in motivos)
                        {
                            registro.Motivos.Add(txt.InnerText);
                        }
                    }
                    else
                    {
                        try
                        {
                            texto = nodeHtmlDoc .DocumentNode.SelectSingleNode("td/text()").OuterHtml;    
                        }
                        catch
                        {
                            texto = String.Empty;
                        }

                        registro.Texto = texto.Trim();
                    }
                }

                registros.Add(registro);
            }

            return registros;
        }

    }
}