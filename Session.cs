using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    internal class Session
    {
        public List<Isp> Session1;
        public Session()
        {
            Session1 = new List<Isp>();
        }

        public void Push(Isp El)
        {
            Session1.Add(El);
        }

        public void Delete(Isp El)
        {
            for (int i = 0; i < Session1.Count; i++)
            {
                if (El.Equals(Session1[i]))
                {
                    Session1.RemoveAt(i);
                }
            }
        }

        public void Show()
        {
            Console.WriteLine("Your isp : ");
            for (int i = 0; i < Session1.Count; i++)
            {
                Session1[i].Show();
            }
            Console.WriteLine();
        }
    }
}
