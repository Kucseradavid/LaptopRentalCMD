using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopRentalCMD
{
    internal class Rental
    {
        public string PersonalID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Postalcode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public string InvNumber { get; set; }
        public string Model { get; set; }
        public string County { get; set; }
        public int RAM { get; set; }
        public string Color { get; set; }
        public int DailyFee { get; set; }
        public int Deposit { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool UseDeposit { get; set; }
        public double Uptime { get; set; }


        public Rental() { }


        public Rental(string sor)
        {
            string[] soradatok = sor.Split(";");

            this.PersonalID = soradatok[0];
            this.Name = soradatok[1];
            this.DateOfBirth = Convert.ToDateTime(soradatok[2]);
            this.Postalcode = Convert.ToInt32(soradatok[3]);
            this.City = soradatok[4];
            this.Address = soradatok[5];

            this.InvNumber = soradatok[6];
            this.Model = soradatok[7];
            this.County = soradatok[8];
            this.RAM = Convert.ToInt32(soradatok[9]);
            this.Color = soradatok[10];
            this.DailyFee = Convert.ToInt32(soradatok[11]);
            this.Deposit = Convert.ToInt32(soradatok[12]);

            this.StartDate = Convert.ToDateTime(soradatok[13]);
            this.EndDate = Convert.ToDateTime(soradatok[14]);
            if (Convert.ToInt32(soradatok[15]) == 0) this.UseDeposit = false;
            else this.UseDeposit = true;
            this.Uptime = Convert.ToDouble(soradatok[16]);
        }

        public override string ToString()
        {
            return $"{this.PersonalID}, {this.DateOfBirth}, {this.Postalcode}, {this.UseDeposit}";
        }

        public double AvgUpTime(List<Rental> forraslista)
        {
            List<Rental> elofordulasok = new List<Rental>();
            foreach (Rental adat in forraslista)
            {
                if (this.InvNumber == adat.InvNumber)
                {
                    elofordulasok.Add(adat);
                }
            }
            double ossz = 0;
            foreach (Rental adat in elofordulasok)
            {
                ossz += adat.Uptime;
            }
            return Math.Round(ossz/elofordulasok.Count(), 2);
        }
    }
}
