namespace DAY2_LINQ
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public string PhoneNumber { get; set; }
        public string IsGraduated { get; set; }
        public string FullName
        {
            get
            {
                return string.Format(FirstName + " " + LastName);
            }
        }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }
        public string Info
        {
            get
            {
                return string.Format("First Name: {0}\r\n"
                + "LastName: {1}\r\n"
                + "Gender: {2}\r\n"
                + "Date of Birth: {3}\r\n"
                + "Phone Number: {4}\r\n"
                + "BirthPlace: {5}\r\n"
                + "Age: {6}\r\n"
                + "IsGraduated: {7}\r\n"
                , FirstName
                , LastName
                , Gender
                , DateOfBirth
                , PhoneNumber
                , BirthPlace
                , Age
                , IsGraduated);
            }
        }
    }
}