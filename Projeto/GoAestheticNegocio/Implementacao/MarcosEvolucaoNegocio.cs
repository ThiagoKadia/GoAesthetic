﻿using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAestheticNegocio.Helpers;
using GoAestheticNegocio.Implementacao.ImplementacaoBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticNegocio.Implementacao
{
    public class MarcosEvolucaoNegocio : BaseNegocio
    {
        public MarcosEvolucaoNegocio(GoAestheticDbContext context) : base(context)
        {
        }

        public async Task<List<MarcosEvolucaoViewModel>> BuscarMarcosComFotos(int idUsuario)
        {
            var listaMarcosEvolucao = await Contexto.MarcosEvolucaoViewModel.Where(m => m.UsuarioId == idUsuario && m.NomeArquivoFoto != null)
                                                                            .OrderBy(m => m.DataInclusao)
                                                                            .AsNoTracking()
                                                                            .ToListAsync();
            
            if(listaMarcosEvolucao.Count == 0)
                return listaMarcosEvolucao;


            var storageHelper = new StorageHelper();
            foreach(var marco in listaMarcosEvolucao)
            {
                marco.UrlArquivoStorage = storageHelper.DownloadImageURI(marco.NomeArquivoFoto);
            }

            return listaMarcosEvolucao;
        }
    }
}