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
            ParkbeheerContext ctx = new ParkbeheerContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            #region HUURCONTRACTEN

            IContractenRepository crepo = new ContractenRepositoryEF(ctx);
            BeheerContracten contractBeheerder = new BeheerContracten(crepo);

            #region POST
            Huurperiode huurperiode = new Huurperiode(DateTime.Now, 10);
            Huurder huurder = new Huurder(2, "Jos", new Contactgegevens("email1", "tel", "adres"));
            Huis huis = new Huis(1, "Kerkstraat", 5, true, new Park("p1", "Buitenhoeve", "Deinze"));
            contractBeheerder.MaakContract("c2", huurperiode, huurder, huis);
            #endregion

            #region GET
            DateTime beginDatum = new DateTime(2023, 10, 12);
            DateTime eindDatum = new DateTime(2024, 10, 12);
            contractBeheerder.GeefContracten(beginDatum, eindDatum);
            #endregion

            #region PUT
            Huurperiode huurperiodeUpdate = new Huurperiode(DateTime.Now, 10);
            Huurder huurderUpdate = new Huurder(2, "update", new Contactgegevens("update", "update", "update"));
            Huis huisUpdate = new Huis(1, "update", 5, true, new Park("p1", "update", "update"));
            Huurcontract huurcontractUpdate = new Huurcontract("c2", huurperiodeUpdate, huurderUpdate, huisUpdate);
            contractBeheerder.UpdateContract(huurcontractUpdate);
            #endregion

            #region DELETE
            //contractBeheerder.AnnuleerContract(huurcontractUpdate);
            #endregion

            #endregion

            #region HUURDERS

            IHuurderRepository hurepo = new HuurderRepositoryEF(ctx);
            BeheerHuurders huurdersBeheerder = new BeheerHuurders(hurepo);

            // POST
            Contactgegevens contactgegevens = new Contactgegevens("testmail", "testtel", "testadres");
            huurdersBeheerder.VoegNieuweHuurderToe("testnaam",contactgegevens);

            // GET            

            // PUT

            // DELETE

            #endregion

            #region HUIZEN

            IHuizenRepository hrepo = new HuizenRepositoryEF(ctx);
            BeheerHuizen huizenBeheerder = new BeheerHuizen(hrepo);

            // POST
            Park park = new Park("p1", "testpark", "testlocatie");
            huizenBeheerder.VoegNieuwHuisToe("garenstraat", 5, park);

            // GET            

            // PUT

            // DELETE

            #endregion

        }
    }
}
