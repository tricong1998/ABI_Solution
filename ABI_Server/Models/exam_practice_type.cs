//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABI_Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class exam_practice_type
    {
        public int id { get; set; }
        public int exam_id { get; set; }
        public int type_id { get; set; }
        public System.DateTime create_at { get; set; }
    
        public virtual exam exam { get; set; }
        public virtual practice_type practice_type { get; set; }
    }
}
