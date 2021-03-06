﻿using LukBank.Models;
using System;
using System.Linq;

namespace LukBank.Model.Services
{
    static class ContasService
    {
        private static Context _context = new Context();

        public static Contas CriarConta(int agencia, string tipoConta)
        {
            Contas contas = null;
            int numeroRandom;
            Random random = new Random();
            var validaNumeroConta = true;

            try
            {
                contas = new Contas() { Agencia = agencia, TipoConta = tipoConta, Ativo = true};

                do
                {
                    numeroRandom = random.Next();

                    foreach (var contaDb in _context.Contas.ToList())
                    {
                        if (contaDb.Numero == numeroRandom)
                            validaNumeroConta = false;
                    }
                } while (!validaNumeroConta);

                contas.Numero = numeroRandom;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Houve um erro ao realizar a criação do número: {e}");
            }

            return contas;
        }
    }
}
