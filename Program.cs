using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    interface IGradExam//позволяют определить требования к реализации 
    {
        void Show();
    }

    public class Exam : Isp
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        public override void FirstQuestion()
        {
            if (Questions.Count > 0)
            {
                Console.WriteLine(Questions[0]);
            }
        }

        public virtual void Show()//полиморфный интерфейс в базовом классе набор членов класса, которые могут быть переопределены в классе-наследнике
        {
            Console.WriteLine($"Name : {name}    GradExam mark : {GradExam}");
        }
    }

    class First : Exam
    {
        public override string ToString()
        {
            return ($"Type : First Exam , Name : {name}, GradExam mark : {GradExam}");
        }
    }

    public partial class Test : Isp
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        public override void FirstQuestion()
        {
            if (Questions.Count > 0)
            {
                Console.WriteLine(Questions[0]);
            }
        }

        public virtual void Show()
        {
            Console.WriteLine($"Type: Test , Name: {name} , GradExam mark  : {GradExam}");
        }
    }

    public abstract class Isp : IGradExam
    {//Служит только для порождения потомков предоставляют базовый функционал для классов-наследников
        public abstract void FirstQuestion();
        public string name;
        public int kolvo;
        public int GradExam;
        public override string ToString()
        {
            return ($"Type: Isp , Name: {name} , GradExam mark  : {GradExam}");
        }

        public virtual void Show()
        {
            Console.WriteLine($"Work with virtual and override in class Isp: Name : {name}    GradExam : {GradExam}");
        }
    }

    public sealed class Question : Isp //класс герметизированный  (бесплодный)
    {//класс, от которого наследовать запрещается
        new readonly string name = "Question 1";
        public override void FirstQuestion()
        {
            Console.WriteLine($"Work with abstract class : Type Question: {name}");        
        }
    }

    class Printer
    {
        public virtual void IAmPrinting(IGradExam someEx)
        {
            Console.WriteLine(someEx.GetType());
            Console.WriteLine(someEx.ToString());
        }
    }
    // добавьте  к существующим классам перечисление и структуру. 
    struct User
    {
        public string name;
        public int age;

        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name : {name}     Age : {age}");
        }
    }
    enum Operation
    {
        Add = 1, Substruct, Multiply
    }

    class Program
    {
        static void Main(string[] args)
        {
            Exam first = new First() { name = "Math", GradExam = 9, kolvo=4 };
            Isp quest = new Question() { name = "Graphic", GradExam = 7};
            quest.Show();
            first.Show();

            Console.WriteLine();
            Test task = new Test() { name = "Grammar (16quest)", GradExam = 10, kolvo=7 };
            task.Show();
            Question tom = new Question() { name = "Gr (8quest)", GradExam = 6, kolvo = 1 };
            tom.Show();

            Console.WriteLine();
            Question exam = new Question() { name = "Litersture", kolvo=3 };
            exam.FirstQuestion();
            exam.Show();

            Console.WriteLine();
            IGradExam first1 = new First() { name = "Music", GradExam = 9, kolvo=9 };  //Обращение через интерфейсную ссылку
            first1.Show();
            IGradExam test = new Test() { name = "Chemistry", GradExam = 5, kolvo=6 };
            test.Show();
          
           
            //операторы is и as
            Console.WriteLine();
            Test test1 = new Test();
            Boolean checkProd = test1 is Test;
            if (checkProd == true)
            {//Возвращает булевское значение, говорящее о том,
                //можете ли вы преобразовать данное выражение в указанный тип
                Console.WriteLine("test1 is Test");
            }
            Console.WriteLine("test1 {0} System.ValueType",
                test is ValueType ? "is" : "is not");
            Console.WriteLine("test1 {0} Test",
                test is Test ? "is" : "is not");
            // позволяет преобразовывать тип в определенный ссылочный тип
            Console.WriteLine();
            Question second = new Question();
            Isp QSecond = second as Isp;
            QSecond.FirstQuestion();

            Console.WriteLine();
            IGradExam[] array = new IGradExam[4];
            array[0] = first;
            array[1] = quest;
            array[2] = test;
            array[3] = exam;
            Printer printer = new Printer();
            for (int i = 0; i < 4; i++)
            {
                printer.IAmPrinting(array[i]);
            }

            User user1;
            user1.name = "User1";
            user1.age = 19;
            user1.DisplayInfo();

            User user2 = new User("User2", 23);
            user2.DisplayInfo();

            user1 = user2; //Переменные хранят не ссылку на объект, а сам объект. Т.е. при присваивании одной структуре другую, скопируются все поля
            user1.DisplayInfo();
            Console.WriteLine();

            Operation op;
            op = Operation.Add;
            Console.WriteLine((int)op);
            op = Operation.Multiply;
            Console.WriteLine(op);
            Console.WriteLine();

            task.Questions.Add(new Question() { name = "Litr", kolvo = 3 });
            task.Questions.Add(new Question() { name = "Bio", kolvo = 5 });
            task.Questions.Add(new Question() { name = "Mat", kolvo = 10 });
            task.Questions.Add(new Question() { name = "Phiz", kolvo = 15 });
            task.Questions.Add(new Question() { name = "Chim", kolvo = 10 });

            Session Session = new Session();
            Session.Push(first);
            Session.Push(exam);
            Session.Push(quest);
            Session.Push(task);

            Session.Show();
            Console.WriteLine();

            Session.Delete(tom);
            Session.Show();
            Console.WriteLine();
        
            Controller ses = new Controller(Session);
            
            Console.WriteLine("vse isp: " + ses.GetCount());
            
            Console.WriteLine("kolvo testov: " + ses.GetTestCount(5));

            Console.ReadLine();
        }
    }
}
