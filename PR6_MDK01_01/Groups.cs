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
    
    public partial class Groups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Groups()
        {
            this.Lessons = new HashSet<Lessons>();
            this.Students = new HashSet<Students>();
            this.StudyPlan = new HashSet<StudyPlan>();
        }
    
        public int IdGroup { get; set; }
        public string NameGroup { get; set; }
        public int IdSpecialization { get; set; }
        public int IdKurs { get; set; }
        public int IdFormOfTraining { get; set; }
    
        public virtual FormOfTrainings FormOfTrainings { get; set; }
        public virtual Kurses Kurses { get; set; }
        public virtual Specializations Specializations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lessons> Lessons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudyPlan> StudyPlan { get; set; }
    }
}
