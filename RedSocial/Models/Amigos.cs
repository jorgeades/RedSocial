//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedSocialApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Amigos
    {
        public int idUsuario { get; set; }
        public int idAmigo { get; set; }
        public bool aceptado { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
