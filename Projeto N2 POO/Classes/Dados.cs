﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Projeto_N2_POO.Enumeradores;

namespace Projeto_N2_POO.Classes
{
    static class Dados
    {
        public static List<Marca> Marcas { get; private set; }
        public static List<Modelo> Modelos { get; private set; }
        public static List<Pedagio> Pedagios { get; private set; }
        public static List<VeiculoBase> Veiculos { get; private set; }

        public static void LerMarcas()
        {
            if (File.Exists("marcas.json"))
            {
                string conteudo = File.ReadAllText("marcas.json", Encoding.UTF8);
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                Marcas = JsonConvert.DeserializeObject<List<Marca>>(conteudo, settings);
            }
            else
                Marcas = new List<Marca>();
        }
        public static void SalvarMarcas()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string conteudo = JsonConvert.SerializeObject(Marcas, settings);

            File.WriteAllText("marcas.json", conteudo, Encoding.UTF8);
        }
        public static void AdicionarMarca(Marca marca)
        {
            foreach (Marca marcaSalva in Marcas)
                if (marcaSalva.Codigo == marca.Codigo)
                    throw new Exception("O código utilizado nessa marca já foi cadastrado.");

            Marcas.Add(marca);
            SalvarMarcas();
        }

        public static void LerModelo()
        {
            if (File.Exists("modelos.json"))
            {
                string conteudo = File.ReadAllText("modelos.json", Encoding.UTF8);
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                Modelos = JsonConvert.DeserializeObject<List<Modelo>>(conteudo, settings);
            }
            else
                Modelos = new List<Modelo>();
        }
        public static void SalvarModelos()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string conteudo = JsonConvert.SerializeObject(Modelos, settings);

            File.WriteAllText("modelos.json", conteudo, Encoding.UTF8);
        }
        public static void AdicionarModelo(Modelo modelo)
        {
            foreach (Modelo modeloSalvo in Modelos)
                if (modeloSalvo.Codigo == modelo.Codigo && modeloSalvo.Marca.Codigo == modelo.Marca.Codigo)
                    throw new Exception("O código utilizado nesse modelo já foi cadastrado.");

            Modelos.Add(modelo);
            SalvarModelos();
        }
        public static List<Modelo> PesquisarModelos(EnumTipoVeiculo tipo)
        {
            List<Modelo> aux = new List<Modelo>();

            foreach (Modelo modelo in Modelos)
                if (modelo.TipoVeiculo == tipo)
                    aux.Add(modelo);

            return aux;
        }

        public static void LerPedagio()
        {
            if (File.Exists("pedagios.json"))
            {
                string conteudo = File.ReadAllText("pedagios.json", Encoding.UTF8);
                JsonSerializerSettings settings = new JsonSerializerSettings{ TypeNameHandling = TypeNameHandling.All};
                Pedagios = JsonConvert.DeserializeObject<List<Pedagio>>(conteudo, settings);
            }
            else
                Pedagios = new List<Pedagio>();
        }
        public static void SalvarPedagios()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string conteudo = JsonConvert.SerializeObject(Pedagios, settings);

            File.WriteAllText("pedagios.json", conteudo, Encoding.UTF8);
        }
        public static void AdicionarPedagio(Pedagio pedagio)
        {
            foreach (Pedagio pedagioSalvo in Pedagios)
                if (pedagioSalvo.Identificacao == pedagio.Identificacao)
                    throw new Exception("A identificação desse pedágio já foi cadastrada.");

            Pedagios.Add(pedagio);
            SalvarPedagios();
        }

        public static void LerVeiculo()
        {
            if (File.Exists("veiculos.json"))
            {
                string conteudo = File.ReadAllText("veiculos.json", Encoding.UTF8);
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                Veiculos = JsonConvert.DeserializeObject<List<VeiculoBase>>(conteudo, settings);
            }
            else
                Veiculos = new List<VeiculoBase>();
        }
        public static void SalvarVeiculos()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string conteudo = JsonConvert.SerializeObject(Veiculos, settings);

            File.WriteAllText("veiculos.json", conteudo, Encoding.UTF8);
        }
        public static void AdicionarVeiculo(VeiculoBase veiculo)
        {
            foreach (VeiculoBase veiculoSalvo in Veiculos)
                if (veiculoSalvo.Identificacao == veiculo.Identificacao)
                    throw new Exception("A identificação desse veiculo já foi cadastrada.");

            Veiculos.Add(veiculo);
            SalvarVeiculos();
        }
    }
}
