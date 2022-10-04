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
                    FirstName = "Bui",
                    LastName = "Da",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2001, 1, 1),
                    PhoneNumber = "0123444333",
                    BirthPlace = "HaNoi",
                    IsGraduated = "No"
                },
                new Member
                {
                    FirstName = "Anh",
                    LastName = "Tuan",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1999, 1, 1),
                    PhoneNumber = "0123444555",
                    BirthPlace = "HaNoi",
                    IsGraduated = "Yes"
                },
                new Member
                {
                    FirstName = "Dat",
                    LastName = "Bui",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    PhoneNumber = "0123444444",
                    BirthPlace = "HaNoi",
                    IsGraduated = "Yes"
                }
            };

            Console.WriteLine("Member Console App\n");
            int option = 0;

            do
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("1. Cau1: Return a list of members who is Male");
                Console.WriteLine("2. Cau2: Return the oldest one based on “Age”");
                Console.WriteLine("3. Cau3: Return a new list that contains Full Name only");
                Console.WriteLine("4. Cau4: Return all member with 1 option");
                Console.WriteLine("5. Cau5: Return the first person who was born in Ha Noi.");
                Console.WriteLine("Other. Exit");
                Console.WriteLine("Your option: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        {
                            Console.WriteLine("----------------");
                            Console.WriteLine("Cau1: Return a list of members who is Male\n");
                            var maleMember = members.FindAll(m => m.Gender == "Male").ToList();
                            maleMember.ForEach(m => Console.WriteLine(m.Info));
                        }
                        break;
                    case 2:

                        {
                            Console.WriteLine("----------------");
                            Console.WriteLine("Cau2: Return the oldest one based on “Age”\n");
                            var maxAge = members.Max(m => m.Age);
                            Member oldestMember = members.First(x => x.Age == maxAge);
                            Console.WriteLine(oldestMember.Info);
                        }
                        break;
                    case 3:

                        {
                            Console.WriteLine("----------------");
                            Console.WriteLine(
                                "Cau3: Return a new list that contains Full Name only\n"
                            );
                            var fullName = members
                                .Select(m => new { FullName = m.FirstName + " " + m.LastName })
                                .ToList();
                            fullName.ForEach(m => Console.WriteLine(m.FullName));
                        }
                        break;
                    case 4:

                        {
                            Console.WriteLine("----------------");
                            Console.WriteLine("Cau4: Return all member with 1 option\n");
                            var yearOfBirth2000 = members.FindAll(m => m.DateOfBirth.Year == 2000);
                            var yearOfBirthGreater2000 = members.FindAll(
                                m => m.DateOfBirth.Year > 2000
                            );
                            var yearOfBirthLess2000 = members.FindAll(
                                m => m.DateOfBirth.Year < 2000
                            );

                            do
                            {
                                Console.WriteLine("1. List of members who has birth year is 2000");
                                Console.WriteLine(
                                    "2. List of members who has birth year greaterthan 2000"
                                );
                                Console.WriteLine(
                                    "3. List of members who has birth year lessthan 2000"
                                );
                                Console.WriteLine("Other. Exit");
                                Console.WriteLine("Your option: ");
                                option = Convert.ToInt32(Console.ReadLine());

                                switch (option)
                                {
                                    case 1:

                                        {
                                            Console.WriteLine("----------------");
                                            Console.WriteLine(
                                                "\nList member birth year is 2000 : "
                                            );
                                            yearOfBirth2000.ForEach(m => Console.WriteLine(m.Info));
                                        }
                                        break;
                                    case 2:

                                        {
                                            Console.WriteLine("----------------");
                                            Console.WriteLine(
                                                "\nList member birth year less 2000 :"
                                            );
                                            yearOfBirthLess2000.ForEach(
                                                m => Console.WriteLine(m.Info)
                                            );
                                        }
                                        break;
                                    case 3:

                                        {
                                            Console.WriteLine("----------------");
                                            Console.WriteLine(
                                                "\nList member birth year more 2000 :"
                                            );
                                            yearOfBirthGreater2000.ForEach(
                                                m => Console.WriteLine(m.Info)
                                            );
                                        }
                                        break;
                                }
                            } while (option >= 1 && option <= 3);
                        }
                        break;
                    case 5:

                        {
                            Console.WriteLine("----------------");
                            Console.WriteLine(
                                "Cau5: Return the first person who was born in Ha Noi.\n"
                            );
                            var bornHanoi = members.SkipWhile(m => m.BirthPlace != "HaNoi");

                            if (bornHanoi.Any())
                            {
                                Console.WriteLine(bornHanoi.First().Info);
                            }
                        }
                        break;
                }
            } while (option >= 1 && option <= 5);
        }
    }
}
