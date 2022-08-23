using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Autofac;
using Infrastructure;
using Infrastructure.Mapping;
using Persistence.Repositories;
using Persistence.UnitOfWork;
using System.Reflection;

namespace WebAPI.Modules
{
    public class RepoServiceModule
    {
        //autofac ile startup.cs'deki builder'larımı buraya taşıyacağım.
    }
}