namespace hermes_datadome_interstitial_solver
{
    internal class Program
    {
        static void Main()
        {
            //from ddm object
            string cid = "";
            string hash = "";
            string seed = "";

            var encoder = new PayloadBuilder(cid, hash);
            var t1 = double.Parse("5." + Random.Shared.Next(1111111111, int.MaxValue) + Random.Shared.Next(11111, 99999));
            var t2 = double.Parse("3." + Random.Shared.Next(1111111111, int.MaxValue) + Random.Shared.Next(11111, 99999));
            encoder.AddPair("tagpu", t1);
            encoder.AddPair("tagpu", t2);
            encoder.AddPair("plgod", false);
            encoder.AddPair("plg", 5);
            encoder.AddPair("plgne", true);
            encoder.AddPair("plgre", true);
            encoder.AddPair("plgof", false);
            encoder.AddPair("plggt", false);
            encoder.AddPair("pltod", false);
            encoder.AddPair("psn", true);
            encoder.AddPair("edp", false);
            encoder.AddPair("addt", false);
            encoder.AddPair("wsdc", true);
            encoder.AddPair("ccsr", false);
            encoder.AddPair("nuad", false);
            encoder.AddPair("bcda", false);
            encoder.AddPair("idn", true);
            encoder.AddPair("capi", false);
            encoder.AddPair("svde", false);
            encoder.AddPair("vpbq", true);
            encoder.AddPair("dvm", -1);
            encoder.AddPair("vco", "");
            encoder.AddPair("vco", "NA");
            encoder.AddPair("vch", "NA");
            encoder.AddPair("vcw", "NA");
            encoder.AddPair("vc3", "NA");
            encoder.AddPair("vcmp", "NA");
            encoder.AddPair("vcq", "NA");
            encoder.AddPair("vc1", "NA");
            encoder.AddPair("vcots", "NA");
            encoder.AddPair("vchts", "NA");
            encoder.AddPair("vcwts", "NA");
            encoder.AddPair("vc3ts", "NA");
            encoder.AddPair("vcmpts", "NA");
            encoder.AddPair("vcqts", "NA");
            encoder.AddPair("vc1ts", "NA");
            encoder.AddPair("aco", "");
            encoder.AddPair("aco", "NA");
            encoder.AddPair("acmp", "NA");
            encoder.AddPair("acw", "NA");
            encoder.AddPair("acma", "NA");
            encoder.AddPair("acaa", "NA");
            encoder.AddPair("ac3", "NA");
            encoder.AddPair("acf", "NA");
            encoder.AddPair("acmp4", "NA");
            encoder.AddPair("acmp3", "NA");
            encoder.AddPair("acwm", "NA");
            encoder.AddPair("acots", "NA");
            encoder.AddPair("acmpts", "NA");
            encoder.AddPair("acwts", "NA");
            encoder.AddPair("acmats", "NA");
            encoder.AddPair("acaats", "NA");
            encoder.AddPair("ac3ts", "NA");
            encoder.AddPair("acfts", "NA");
            encoder.AddPair("acmp4ts", "NA");
            encoder.AddPair("acmp3ts", "NA");
            encoder.AddPair("acwmts", "NA");
            encoder.AddPair("lg", "fr-FR");
            encoder.AddPair("npmtm", "NA");
            encoder.AddPair("phe", false);
            encoder.AddPair("nm", false);
            encoder.AddPair("awe", false);
            encoder.AddPair("geb", false);
            encoder.AddPair("dat", false);
            encoder.AddPair("sqt", false);
            encoder.AddPair("ucdv", false);
            encoder.AddPair("tzp", "Europe/Paris");
            encoder.AddPair("tz", -120);
            encoder.AddPair("rs_w", 390);
            encoder.AddPair("rs_h", 844);
            encoder.AddPair("isb", false);
            encoder.AddPair("plu", "PDF Viewer,Chrome PDF Viewer,Chromium PDF Viewer,Microsoft Edge PDF Viewer,WebKit built-in PDF");
            encoder.AddPair("mmt", "application/pdf,text/pdf");
            encoder.AddPair("hcovdr", false);
            encoder.AddPair("plovdr", false);
            encoder.AddPair("ftsovdr", false);
            encoder.AddPair("hcovdr2", false);
            encoder.AddPair("plovdr2", false);
            encoder.AddPair("ftsovdr2", false);
            encoder.AddPair("glvd", "Apple Inc.");
            encoder.AddPair("glrd", "Apple GPU");
            encoder.AddPair("hc", 4);
            encoder.AddPair("br_oh", 844);
            encoder.AddPair("br_ow", 390);
            encoder.AddPair("ua", "Mozilla/5.0 (iPhone; CPU iPhone OS 16_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.0 Mobile/15E148 Safari/604.1");
            encoder.AddPair("wbd", false);
            encoder.AddPair("ts_mtp", 5);
            encoder.AddPair("wwl", false);
            encoder.AddPair("response", PayloadBuilder.EncodeSeed(seed));

            var payload = encoder.Build();
            Console.WriteLine(payload);
        }
    }
}