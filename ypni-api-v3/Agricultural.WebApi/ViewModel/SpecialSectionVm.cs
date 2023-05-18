namespace Agricultural.WebApi.ViewModel
{
    public class SpecialSectionVm
    {
        public int Id { get; set; }
        public string SpecialSectionName { get; set; } 
        public string ImageUrl { get; set; }
        public int? MainClassificationId { get; set; }
        public int? AdditionalSectionsId { get; set; }
        public int? ParnetSectionId { get; set; }
        public int Rank { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }



        public class SpecialSectionViewModel 
        {
            public string? imageUrl { get; set; }
            public string specialsectionVm { get; set; }


        }
    }
}
