//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Calanthe
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vocabulary
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Word { get; set; }
        public string Translation { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
