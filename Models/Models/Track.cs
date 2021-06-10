namespace Models
{
    public class Track
    {
        public int ID { get; set; }
        public Location Location { get; set; }
        public bool Occupied { get; set; }
        public int Duration { get; set; }
        public Role Role { get; set; }
    }
}
