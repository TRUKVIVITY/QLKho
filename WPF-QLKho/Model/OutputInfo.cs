//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_QLKho.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class OutputInfo
    {
        public int Id { get; set; }
        public Nullable<int> IdOutput { get; set; }
        public Nullable<int> IdInputInfo { get; set; }
        public Nullable<int> Counts { get; set; }
        public Nullable<double> JungleTax { get; set; }
        public Nullable<int> Sale { get; set; }
        public string OutputStatus { get; set; }
        public Nullable<int> IdObject { get; set; }
    
        public virtual InputInfo InputInfo { get; set; }
        public virtual tObject tObject { get; set; }
        public virtual tOutput tOutput { get; set; }
    }
}