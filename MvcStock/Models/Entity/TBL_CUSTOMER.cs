﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStock.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBL_CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_CUSTOMER()
        {
            this.TBLSALES = new HashSet<TBLSALE>();
        }
    
        public int CUSTOMERID { get; set; }
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz!")]
        [StringLength(50,ErrorMessage ="En fazla 50 karakter!")]
        public string CUSTOMERNAME { get; set; }
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz!")]
        [StringLength(50,ErrorMessage ="En fazla 50 karakter!")]
        public string CUSTOMERSURNAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSALE> TBLSALES { get; set; }
    }
}
