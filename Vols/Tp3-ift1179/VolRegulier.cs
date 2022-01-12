using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tp3_ift1179
{
    [Serializable()]
    class VolRegulier :Vol
    {
        //public const string AFFAIRES = "1";
        // public const string PREMIERE = "2";
        //public const string ECONOMIQUE = "3";
        private bool repas;
        private bool siege;
        private bool bar;
        private bool divertissement;
        private bool servicePay;
        private bool wifi;
        public VolRegulier (string categorie,string num, string dest, Date date, string nbTotalR,string typeAvion) : base(categorie,num, dest, date, nbTotalR, typeAvion)
        {
            this.repas = true;
            this.siege = true;
            this.bar = false;
            this.divertissement = true;
            this.servicePay = true;
            this.wifi = false;
        }
        public bool Repas
        {
            get { return repas; }
            set { repas = value; }
        }
        public bool Siege
        {
            get { return siege; }
            set { siege = value; }
        }
        public bool Bar
        {
            get { return bar; }
            set { bar = value; }
        }
        public bool Divertissement
        {
            get { return divertissement; }
            set { divertissement = value; }
        }
        public bool ServicePay
        {
            get { return servicePay; }
            set { servicePay = value; }
        }
        public bool Wifi
        {
            get { return wifi; }
            set { wifi = value; }
        }
    }
}
