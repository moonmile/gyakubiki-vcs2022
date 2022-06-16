namespace ref454Lib
{
    public class Sample
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string ShowData()
        {
            return $"{Id} : {Name} in {Address}";
        }
    }
}