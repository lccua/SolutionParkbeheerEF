using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer;
using ParkDataLayer.Context;
using ParkDataLayer.Model;
using ParkDataLayer.Repositories;
using System;

namespace ConsoleAppModelTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Initialize the context and ensure database is created
            #region Database Initialization
            ParkbeheerContext ctx = new ParkbeheerContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            #endregion

            // Repository and management for houses
            #region Beheer Huizen
            IHuizenRepository huizenRepository = new HuizenRepositoryEF(ctx);
            BeheerHuizen beheerHuizen = new BeheerHuizen(huizenRepository);

            Park park1 = new Park("p1", "test1", "Gent");
            Park park2 = new Park("p2", "test2", "Gent");
            Park park3 = new Park("p3", "test3", "Gent");


            beheerHuizen.VoegNieuwHuisToe("parklaan", 1, park1);
            beheerHuizen.VoegNieuwHuisToe("parklaan", 2, park2);
            beheerHuizen.VoegNieuwHuisToe("parklaan", 3, park3);

            Huis huis1 = beheerHuizen.GeefHuis(1);
            huis1.ZetStraat("Kerkstraat");
            huis1.ZetNr(11);
            beheerHuizen.UpdateHuis(huis1);
            beheerHuizen.ArchiveerHuis(huis1);
            #endregion


            // Repository and management for renters
            #region Beheer Huurders
            IHuurderRepository huurderRepository = new HuurderRepositoryEF(ctx);
            BeheerHuurders beheerHuurders = new BeheerHuurders(huurderRepository);

            beheerHuurders.VoegNieuweHuurderToe("jos", new Contactgegevens("email1", "tel", "adres"));
            beheerHuurders.VoegNieuweHuurderToe("jef", new Contactgegevens("email2", "tel", "adres"));
            #endregion

            // Repository and management for contracts
            #region Beheer Contracten
            IContractenRepository contractenRepository = new ContractenRepositoryEF(ctx);
            BeheerContracten beheerContracten = new BeheerContracten(contractenRepository);

            Huurperiode huurPeriode = new Huurperiode(DateTime.Now, 10);

            Huurder huurder3 = new Huurder( "gert", new Contactgegevens("email1", "tel", "adres"));
            Park park4 = new Park("p4", "Buitenhoeve", "Deinze");
            Huis huis2 = new Huis("Kerkstraat", 4, park4);



            beheerContracten.MaakContract("c2", huurPeriode, huurder3, huis2);

            Huurcontract huurcontract = beheerContracten.GeefContract("c2");
            #endregion





        }
    }
}
