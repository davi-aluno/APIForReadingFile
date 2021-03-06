﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("fapen/[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get() => ReadFile();

        public static System.Collections.Generic.List<string> ReadFile()
        {
            string filename = @"files/Produtos.txt";
            List<string> produtos = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string linha;

                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (linha != String.Empty)
                            produtos.Add(linha);
                    }
                    return produtos;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao ler o arquivo" + e.Message);
            }
        }
    }
}