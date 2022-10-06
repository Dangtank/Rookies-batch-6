namespace Day1_Assignment
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
                    IsGraduated = true
                },
                new Member
                {
                    FirstName = "Anh",
                    LastName = "Tuan",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1999, 1, 1),
                    PhoneNumber = "0123444555",
                    BirthPlace = "HaNoi",
                    IsGraduated = false
                },
                new Member 
                {
                    FirstName = "Dat",
                    LastName = "Bui",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    PhoneNumber = "0123444444",
                    BirthPlace = "HaNoi",
                    IsGraduated = true
                }
            };

            Console.WriteLine("Member Console App\n");
            int option = 0;
            int max = 0;

            do
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("1. Cau1: Return a list of members who is Male");
                Console.WriteLine("2. Cau2: Return the oldest one based on “Age”");
                Console.WriteLine("3. Cau3: Return a new list that contains Full Name only");
                Console.WriteLine("4. Cau4: Return all member with 1 option");
                Console.WriteLine("5. Cau5: Return the first person who was born in Ha Noi.");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Your option: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        Console.WriteLine("----------------");
                        Console.WriteLine("Cau1: Return a list of members who is Male\n");

                        foreach (var member in members)
                        {
                            if (member.Gender != "Male")
                            {
                                continue;
                            }

                            Console.WriteLine(member.Info);
                        }
                        break;
                    case 2:

                        Console.WriteLine("----------------");
                        Console.WriteLine("Cau2: Return the oldest one based on “Age”\n");

                        foreach (Member member in members)
                        {
                            if (max < member.Age)
                            {
                                max = member.Age;
                            }

                            if (member.Age == max)
                            {
                                Console.WriteLine(member.Info);
                                break;
                            }
                        }
                        break;
                    case 3:

                        Console.WriteLine("----------------");
                        Console.WriteLine("Cau3: Return a new list that contains Full Name only\n");

                        foreach (Member member in members)
                        {
                            Console.WriteLine(member.FullName);
                        }
                        break;
                    case 4:

                        Console.WriteLine("----------------");
                        Console.WriteLine("Cau4: Return all member with 1 option\n");
                        List<Member> Age2000 = new List<Member>();
                        List<Member> AgeMore2000 = new List<Member>();
                        List<Member> AgeLess2000 = new List<Member>();

                        foreach (Member member in members)
                        {
                            if (member.DateOfBirth.Year == 2000)
                            {
                                Age2000.Add(member);
                                break;
                            }

                            if (member.DateOfBirth.Year < 2000)
                            {
                                AgeLess2000.Add(member);
                                break;
                            }

                            if (member.DateOfBirth.Year > 2000)
                            {
                                AgeMore2000.Add(member);
                                break;
                            }
                        }

                        do
                        {
                            Console.WriteLine("1.List of members who has birth year is 2000");
                            Console.WriteLine(
                                "2.List of members who has birth year greaterthan 2000"
                            );
                            Console.WriteLine("3.List of members who has birth year lessthan 2000");
                            Console.WriteLine("4.exit");
                            Console.WriteLine("Your option: ");
                            option = Convert.ToInt32(Console.ReadLine());

                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("----------------");

                                    {
                                        Console.WriteLine("\nList member birth year is 2000 : ");

                                        foreach (Member member in Age2000)
                                        {
                                            Console.WriteLine(member.Info);
                                        }
                                    }
                                    break;
                                case 2:

                                    {
                                        Console.WriteLine("----------------");

                                        Console.WriteLine("\nList member birth year less 2000 :");

                                        foreach (Member member in AgeLess2000)
                                        {
                                            Console.WriteLine(member.Info);
                                        }
                                    }
                                    break;
                                case 3:

                                    {
                                        Console.WriteLine("----------------");

                                        Console.WriteLine("\nList member birth year more 2000 :");

                                        foreach (Member member in AgeMore2000)
                                        {
                                            Console.WriteLine(member.Info);
                                        }
                                    }
                                    break;
                            }
                        } while (option >= 1 && option <= 3);
                        break;
                    case 5:

                        Console.WriteLine("----------------");
                        Console.WriteLine(
                            "Cau5: Return the first person who was born in Ha Noi.\n"
                        );
                        int flag = 0;

                        while (flag < members.Count)
                        {
                            if (members[flag].BirthPlace == "HaNoi")
                            {
                                Console.WriteLine(members[flag].Info);
                                break;
                            }
                            flag++;
                        }
                        break;
                }
            } while (option >= 1 && option <= 5);
        }
    }
}
