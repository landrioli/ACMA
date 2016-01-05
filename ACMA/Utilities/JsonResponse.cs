using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACMA.Utilities
{
    public class JsonResponse
    {
        private bool _success { get; set; }
        private string _title { get; set; }
        private string _mensagem { get; set; }
        private object _data { get; set; }

        public JsonResponse Success(bool success)
        {
            _success = success;
            return this;
        }

        public JsonResponse Title(string title)
        {
            _title = title;
            return this;
        }

        public JsonResponse Message(string mensagem)
        {
            _mensagem = mensagem;
            return this;
        }

        public JsonResponse Data(object data)
        {
            _data = data;
            return this;
        }

        public JsonResult CreateResponse()
        {
            return new JsonResult()
            {
                Data = new
                {
                    Sucesso = _success,
                    Mensagem = _mensagem,
                    Dados = _data
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}