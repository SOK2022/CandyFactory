//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CandyFactory
{
    using System;
    using System.Collections.Generic;
    
    public partial class CandyCompositionPerOneKg
    {
        public int CandyId { get; set; }
        public int ComponentId { get; set; }
        public Nullable<double> ComponentAmount { get; set; }
        public string CandyName { get; set; }
        public string ComponentName { get; set; }
    
        public virtual Candies Candies { get; set; }
        public virtual Components Components { get; set; }
    }
}