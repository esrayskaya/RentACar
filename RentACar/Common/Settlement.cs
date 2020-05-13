using System;

namespace Common
{
    public class Settlement//населённые пункты
    {
        private int codeCity;
        private string nameCity;
        public int CodeCity
        {
            get { return codeCity; }
            set { if (value <= 0)
                {
                    throw new Exception("Код не может быть отрицательным или равным 0");
                }
                else codeCity = value;
            }
        }
        public string NameCity
        {
            get { return nameCity; }
            set { if (value == String.Empty)
                    throw new Exception("Поле не может быть пустым");
                else nameCity = value;
            }
        }
        public Settlement(int codeCity, string nameCity)
        {
            CodeCity = codeCity;
            NameCity = nameCity;
        }
    }
}
