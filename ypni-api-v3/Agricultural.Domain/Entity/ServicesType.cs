namespace Agricultural.Domain.Entity
{
    public class ServicesType 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public List<ServiceProvider> serviceProviders { get; set; }

        public ServicesType()
        {
            Active = true; 
        }

    }
}
