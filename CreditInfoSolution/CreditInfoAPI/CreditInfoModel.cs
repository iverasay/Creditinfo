namespace CreditInfoAPI
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CreditInfoModel : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'CreditInfoModel' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'CreditInfoAPI.CreditInfoModel' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'CreditInfoModel'  en el archivo de configuración de la aplicación.
        public CreditInfoModel()
            : base("name=CreditInfoModel")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
         public virtual DbSet<Contract> Contracts { get; set; }
         public virtual DbSet<Individual> Individuals { get; set; }
         public virtual DbSet<IdentificationNumber> IdentificationNumbers { get; set; }
         public virtual DbSet<SubjectRole> SubjectRoles { get; set; }
         public virtual DbSet<GuaranteeAmount> GuaranteeAmounts { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class Contract
    {
        public int Id { get; set; }
        public string ContractCode { get; set; }
        public Individual Ind1 { get; set; }
        public Individual Ind2 { get; set; }
        public Individual Ind3 { get; set; }
        public SubjectRole SR1 { get; set; }
        public SubjectRole SR2 { get; set; }
        public SubjectRole SR3 { get; set; }

    }

    public class Individual
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IdentificationNumber IdN { get; set; }

    }

    public class IdentificationNumber
    {
        public int Id { get; set; }
        public string NationalID { get; set; }

    }

    public class SubjectRole
    {
        public int Id { get; set; }
        public string ContractCode { get; set; }
        public int RoleOfCustomer { get; set; }
        public GuaranteeAmount Guarantee { get; set; }

    }

    public class GuaranteeAmount
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public int Currency { get; set; }

    }



}