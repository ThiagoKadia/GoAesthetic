﻿using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAestheticNegocio.Implementacao.ImplementacaoBase;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using GoAestheticComuns.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GoAestheticNegocio.Helpers;

namespace GoAestheticNegocio.Implementacao
{
    public class LoginNegocio : BaseNegocio
    {
        public LoginNegocio(GoAestheticDbContext context) : base(context)
        {
        }

        public async Task<UsuariosViewModel?> VerificaLoginCorreto(string email, string senha)
        {
            string hashSenha = CriptografiaHelper.CriaHashSenha(senha);
            return await Contexto.UsuariosViewModel.Where(x => x.Email == email && x.Senha == hashSenha)
                                                                .Select(u => new UsuariosViewModel()
                                                                {
                                                                    Id = u.Id,
                                                                    Nome = u.Nome,
                                                                    Senha = u.Senha,
                                                                    NomeRole = u.Autorizacao.Role
                                                                })
                                                                .AsNoTracking()
                                                                .FirstOrDefaultAsync();
        }

        public async Task<UsuariosViewModel> CadastraUsuario(UsuariosViewModel usuario)
        {
            using var transaction = Contexto.Database.BeginTransaction();
            {
                usuario.Senha = CriptografiaHelper.CriaHashSenha(usuario.Senha);
                usuario.AutorizacaoId = await Contexto.AutorizacaoViewModel.Where(x => x.Role == Roles.Usuario)
                                                                           .Select(a => a.Id)
                                                                           .FirstAsync();

                usuario.NomeRole = await Contexto.AutorizacaoViewModel.Where(a => a.Id == usuario.AutorizacaoId)
                                                                      .Select(a => a.Role)
                                                                      .FirstAsync();
                Contexto.UsuariosViewModel.Add(usuario);
                await Contexto.SaveChangesAsync();

                var primeiroMarcoEvolucao = new MarcosEvolucaoViewModel()
                {
                    Usuario = usuario.Id,
                    Altura = usuario.Altura,
                    Peso = usuario.Peso,
                    DataInclusao = DateTime.Now
                };
                Contexto.MarcosEvolucaoViewModel.Add(primeiroMarcoEvolucao);
                await Contexto.SaveChangesAsync();

                transaction.Commit();
            }
            return usuario;
        }
    }
}
