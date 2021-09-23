using GSK.HealthProfessional.Model.Helper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSK.HealthProfessional.Model
{
    public class HealthProfessionalModel: GoogleReCaptchaModelBase
    {

        [Key]
        public Guid ProfessionalId { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        [DisplayName("Nome")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Sobrenome")]
        [StringLength(200)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(200)]      
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Redigitar E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(200)]
        [Compare("Email", ErrorMessage = "O campo E-mail e Redigitar E-mail não combinam.")]
        public string RedigitarEmail { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Perfil")]        
        public string OccupationAreaClientUniqueIdentifier { get; set; }        
        
        [ForeignKey("OccupationAreaClientUniqueIdentifier")]        
        public virtual OccupationAreaModel OccupationArea { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Cidade")]
        public string CityId { get; set; }
        
        [ForeignKey("CityId")]
        public virtual CityModel City { get; set; }
                
        public string CityDescription { get; set; }
        public string StateDescription { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Estado")]
        public string StateId { get; set; }
      
        [ForeignKey("StateId")]
        public virtual StateModel State { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Empresa")]
        [StringLength(200)]
        public string CompanyId { get; set; }
        public virtual CompanyModel Company { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Nome da empresa")]
        [StringLength(200)]
        public string CompanyDescription { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Número do conselho")]
        [StringLength(200)]
        public string CouncilNumber { get; set; }
        

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Celular (DDD) + telefone")]              
        public string Phone { get; set; }
        
        [DisplayName("Senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, ErrorMessage = "A senha precisa ter mais de 5 caracteres.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [DisplayName("Confirmação de senha")]
        [StringLength(20, ErrorMessage = "A confirmação de senha precisa ter mais de 5 caracteres.", MinimumLength = 5)]
        [Compare("Password", ErrorMessage="O campo senha e confirmação de senha não combinam.")]
        public string PasswordConfirmation { get; set; }
        
        [DisplayName("Aceito receber informações sobre produtos, campanhas, artigos e eventos da GSK.")]        
        public bool EmailNotification { get; set; }
        
        [DisplayName("Confirmo ser um profissional da saúde.")]
        public bool IsHealthProfessional { get; set; }

        [DisplayName("Aceito o Termo de Consentimento da plataforma.")]        
        public bool AcceptsTermUse { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Código SAP")]
        [StringLength(200)]
        public string CodigoSAP { get; set; }

    }
}
