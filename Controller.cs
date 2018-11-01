using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//подсчитать общее количество испытаний в сессии и 
//количество тестов с заданным числом вопросов. 
namespace _5
{
    class Controller
    {
        public Session ses1 = new Session();

        public Controller(Session ses1)
        {
            this.ses1 = ses1;
        }
        //кол-во всех испытаний
        public int GetCount()
        {
            return ses1.Session1.Count;
        }
        //кол-во тестов с заданным числом вопросов
        public int GetTestCount(int qCount)
        {
            return ses1.Session1.Count(isp => isp is Test && ((Test)isp).Questions.Count == qCount);
        }
    }
}
