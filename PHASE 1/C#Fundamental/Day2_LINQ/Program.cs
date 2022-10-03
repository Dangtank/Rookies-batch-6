namespace DAY2_LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Member> members = new List<Member>
            {
                new Member
                {
                    FirstName = "Do",
                    LastName = "Duc",
                    Gender = "male",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    BirthPlace = "HaNoi"
                },
                new Member
                {
                    FirstName = "Lam",
                    LastName = "Kien",
                    Gender = "male",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    BirthPlace = "HaNoi"
                },
                new Member
                {
                    FirstName = "Hao",
                    LastName = "Ngan",
                    Gender = "male",
                    DateOfBirth = new DateTime(2004, 1, 1),
                    BirthPlace = "Vinh"
                },
            };

            Console.WriteLine("Cau1");
            var maleMember = members.Where(m => m.Gender == "male").ToList();
            maleMember.ForEach(m => Console.WriteLine(m.Info));

            Console.WriteLine("Cau2");
            var MaxAge = members.Max(m => m.Age);

            Member oldestMember = members.First(x => x.Age == MaxAge);

            // Member oldestMember1 = members.FirstOrDefault(x => x.Age == MaxAge);

            // var oldestMember2 = members.Where(x => x.Age == MaxAge).Take(1);

            Console.WriteLine(oldestMember.Info);
            // if (oldestMember != null)
            // {
            //     Console.WriteLine(oldestMember1.Info);
            // }

            // if (oldestMember2.Any())
            // {
            //     foreach (Member m in oldestMember2)
            //     {
            //         Console.WriteLine(m.Info);
            //     }
            // }

            Console.WriteLine("Cau3");
            // List<String> fullName = members.Select(m => m.FirstName + " " + m.LastName).ToList();
            var fullName = members
                .Select(m => new { FullName = m.FirstName + " " + m.LastName })
                .ToList();
            fullName.ForEach(m => Console.WriteLine(m.FullName));

            Console.WriteLine("Cau4");

            var YearOfBirth2000 = members.FindAll(m => m.DateOfBirth.Year == 2000);

            var YearOfBirthGreater2000 = members.FindAll(m => m.DateOfBirth.Year > 2000);

            var YearOfBirthLess2000 = members.FindAll(m => m.DateOfBirth.Year < 2000);

            Console.WriteLine("Year Of Birth = 2000:");
            foreach (var m in YearOfBirth2000)
            {
                Console.WriteLine(m.Info);
            }

            Console.WriteLine("Year Of Birth > 2000:");
            foreach (var m in YearOfBirthGreater2000)
            {
                Console.WriteLine(m.Info);
            }

            Console.WriteLine("Year Of Birth < 2000:");
            foreach (var m in YearOfBirthLess2000)
            {
                Console.WriteLine(m.Info);
            }

            Console.WriteLine("Cau5");
            var BornHanoi = members.FindAll(m => m.BirthPlace == "HaNoi");

            if (BornHanoi.Any()){
                Console.WriteLine(BornHanoi.First().Info);
            }
        }
    }
}
