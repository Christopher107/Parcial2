//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parcial2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VW_REGISTRO
    {
        public Nullable<int> FOLIO { get; set; }
        public Nullable<System.DateTime> FECHA_DE_RECEPCION { get; set; }
        public Nullable<System.DateTime> FECHA_DE_ENTREGA { get; set; }
        public int RUT_DEL_CLIENTE { get; set; }
        public string NOMBRE_DEL_LABORATORIO { get; set; }
        public Nullable<int> CANTIDAD_DE_MUESTRAS { get; set; }
    }
}