using System.ComponentModel.DataAnnotations;


namespace GSK.HealthProfessional.Model
{
    public class OccupationAreaModel 
    {
        [Key]
        public long OccupationAreaID { get; set; }
        public string Name { get; set; }
        public string ClientUniqueIdentifier { get; set; }

    }
}
