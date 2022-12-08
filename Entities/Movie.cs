namespace KinoSGopeto.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Year { get; set; }

        public string Month { get; set; }

        public string ReviewUrl { get; set; }

        public Movie() =>
            this.Id = Guid.NewGuid();
    }
}
