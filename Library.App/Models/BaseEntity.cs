using System;
namespace Library.App.Models
{/// Zakladna trieda pre entity v aplikacii
/// Sluzí na spolocne vlastnosti a splnenie poziadavky dedičnosti
    public abstract class BaseEntity /// Datum vytvorenia záznamu
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}