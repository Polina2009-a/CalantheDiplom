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
    
    public partial class Answers
    {
        public int ID { get; set; }
        public int NumberLesson { get; set; }
        public int NumberQuestion { get; set; }
        public string Answer { get; set; }
    
        public virtual PracticalLesson PracticalLesson { get; set; }
    }
}
