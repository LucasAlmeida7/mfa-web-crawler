
using Microsoft.VisualBasic.CompilerServices;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using CrawlerConsultaRAB.Utils;
using CrawlerConsultaRAB.Catcher;
using CrawlerConsultaRAB.Navigator;

namespace CrawlerConsultaRAB
{
    public class Navigator
    {
        private Utils _utils = new Utils();
        private Connect _connect = new Connect();
        private Catcher _catcher = new Catcher();
        public List<Registro> registros = new List<Registro>();

        public List<Registro> NavToQueryPage(string chave)
        {
            Uri url = _utils.SelectQueryType(1, chave);
            HtmlDocument html = _connect.RequestGET(url);

            registros.AddRange(_catcher.GetData(html));

            return registros;
        }

    }
}