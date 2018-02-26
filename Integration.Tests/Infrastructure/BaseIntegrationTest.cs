using API;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using Repositories.Context;
using System.Net.Http;

namespace Integration.Tests.Infrastructure
{
    public class BaseIntegrationTest
    {
        public DatabaseContext _context { get; set; }
        public HttpClient _client { get; private set; }

        public BaseIntegrationTest()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            ServiceCollectionExtensions.UseStaticRegistration = false;
            var server = new TestServer(builder);
            _context = server.Host.Services.GetService(typeof(DatabaseContext)) as DatabaseContext;
            _client = server.CreateClient();
        }

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            //AutomapperSetup();
            BuildDb();
        }

        private void BuildDb()
        {
            #region Clients Builder
            //_context.Client.AddRange(ClientObjectMother.aListOfClientRepositoriesWithSchedules());
            //_context.Client.AddRange(ClientObjectMother.aListOfClientRepositories());
            //_context.Client.AddRange(foo);
            #endregion

            _context.SaveChanges();
            //var clients =_context.Client.ToList();
            //var schedules = _context.ClientSchedule.ToList();
        }

        //private void AutomapperSetup()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<ClientBuilder, Client>()
        //            .AfterMap((s, d, context) =>
        //            {
        //                s.Schedules.ForEach(x => s.Schedules.Add(context.Mapper.Map<ClientScheduleBuilder,ClientScheduleDto>(x)));
        //            })
        //            .ReverseMap()
        //            ;

        //        cfg.CreateMap<ClientScheduleBuilder, ClientSchedule>()
        //            .ReverseMap()
        //            ;

        //        cfg.CreateMap<List<ClientBuilder>, List<Client>>()
        //            .AfterMap((s, d, context) =>
        //            {
        //                s.ToList().ForEach(x =>
        //                {
        //                    var client = context.Mapper.Map<ClientBuilder, Client>(x);
        //                    d.Add();
        //                });
        //            })
        //            .ReverseMap()
        //            ;
        //    });
        //}

    }
}