//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR6_MDK01_01
{
    using System;
    using System.Collections.Generic;
    
    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            this.MarkStudents = new HashSet<MarkStudents>();
        }
    
        public int IdStudent { get; set; }
        public string Surname { get; set; }
        public string NameStudent { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime Birthday { get; set; }
        public int IdGender { get; set; }
        public int IdSpecialization { get; set; }
        public int IdKurs { get; set; }
        public int IdFormOfTraining { get; set; }
        public int IdGroup { get; set; }
    
        public virtual FormOfTrainings FormOfTrainings { get; set; }
        public virtual Genders Genders { get; set; }
        public virtual Groups Groups { get; set; }
        public virtual Kurses Kurses { get; set; }
        public virtual Logined Logined { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarkStudents> MarkStudents { get; set; }
        public virtual Specializations Specializations { get; set; }
    }
}
