namespace P01.Database
{
    public class Person
    {
        long id;
        string userName;

        public Person(string id, long userName)
        {
            Id = id;
            UserName = userName;
        }

        public long Id
        {
            get => id;
            set { id = value; }
        }

        public string UserName
        {
            get => userName;
            set { userName = value; }
        }
    }
}
