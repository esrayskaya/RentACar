using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Client : Counterpartie
    {
        //private Int64 drivenCertificateClient;
        private int cityLife;
        private int cityRent;
        /*public Int64 DrivenCertificateClient
        {
            get { return drivenCertificateClient; }
            set
            {
                if (value <= 0)
                    throw new Exception("Значение поля не может быть меньше или равно 0");
                else drivenCertificateClient = value;
            }
        }*/
        public int CityLife
        {
            get { return cityLife; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Код не может быть отрицательным или равным 0");
                }
                else cityLife = value;
            }
        }
        public int CityRent
        {
            get { return cityRent; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Код не может быть отрицательным или равным 0");
                }
                else cityRent = value;
            }
        }
        public Client(Int64 drivanSertificate, string lastName, string firstName, 
            string patronymic, Int64 passport, DateTime birthDay
            /*Int64 drivenCertificateClient*/, int cityLife, int cityRent) : base(drivanSertificate, lastName, firstName, patronymic, passport, birthDay)
        {
            //DrivenCertificateClient = drivenCertificateClient;
            CityLife = cityLife;
            CityRent = cityRent;
        }
    }
}
