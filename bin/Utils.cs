
using HtmlAgilityPack;
using System;

namespace CrawlerConsultaRAB
{
    public class Util
    {
        public HtmlDocument ParseToHtmlDocument(string html)
        {
            ParseToHtmlDocument htmlDocument = new ParseToHtmlDocument();
            htmlDocument.LoadHtml(html);

            return htmlDocument;
        }

        public Uri SelectQueryType(int tipo, string chave)
        {
            Uri url = new Uri("https://sistemas.anac.gov.br/areronaves/cons_rab_novo_resposta.asp");
            
            switch (tipo)
            {
                case 1:
                    url = new Uri(
                        String.Format("https://sistemas.anac.gov.br/aeronaves/cons_rab_novo_resposta.asp?textMarca={0}", 
                        chave
                    ));
                    break;

                default:
                    break;
            }

        }


    }
}