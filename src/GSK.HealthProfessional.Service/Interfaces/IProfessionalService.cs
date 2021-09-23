
using GSK.HealthProfessional.Model;

namespace GSK.HealthProfessional.Service.Interfaces
{
    public interface IProfessionalService
    {
        bool Add(HealthProfessionalModel professional);
        bool LinkUserToCompany(string email, string businessUnitCUI, string occupationAreaClientUI, string registrationNumber);
    }
}
