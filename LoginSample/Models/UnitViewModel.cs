using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginSample.Models
{
    public class UnitViewModel
    {
        public TarrifModel Tarrif { get; set; }
        public List<UnitModel> Options { get; set; }

        public UnitViewModel()
        {
            Tarrif = new TarrifModel();

            Options = new List<UnitModel>();
            Options.Add(new UnitModel() { Id = 0 });
            Options.Add(new UnitModel() { Id = 1 });
            Options.Add(new UnitModel() { Id = 2 });
        }
        public UnitViewModel(TarrifModel tarrif)
        {
            Tarrif = tarrif;
            Options = new List<UnitModel>();
            if (tarrif.Options != null)
            {
                if (tarrif.Options.Count > 0)
                {
                    Options = tarrif.Options.ToList();
                }
            }
            
                if (Options == null || (Options != null && Options.Count == 0))
                {
                    Options.Add(new UnitModel() { Id = 0 });
                    Options.Add(new UnitModel() { Id = 1 });
                    Options.Add(new UnitModel() { Id = 2 });
                }
            
        }
    }

    public class TarrifModel
    {
        public string UiD { get; set; }
        public string Utility_Provider_Name { get; set; }
        public string Utility_Type { get; set; }
        public string Tarrif_Master { get; set; }
        public string Taxation { get; set; }
        public List<UnitModel> Options { get; set; }
    }

    public class UnitModel
    {
        public int Id { get; set; }
        public int Startunit { get; set; }
        public int Endunit { get; set; }
        public int Price { get; set; }
    }
}