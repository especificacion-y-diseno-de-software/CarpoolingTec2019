//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarPoolingTecWebApi22019.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NOTIFICACIONE
    {
        public int NO_ID { get; set; }
        public int NO_userID { get; set; }
        public int NO_type { get; set; }
        public string NO_descrip { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
    }
}