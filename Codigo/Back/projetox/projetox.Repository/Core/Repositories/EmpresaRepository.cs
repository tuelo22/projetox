﻿using Microsoft.EntityFrameworkCore;
using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.Interfaces.Repositories;
using projetox.Repository.Base.Repository;

namespace projetox.Repository.Core.Repositories
{
    public class EmpresaRepository(XContext context) : RepositoryBase<Empresa, Guid>(context), IEmpresaRepository
    {
    }
}
