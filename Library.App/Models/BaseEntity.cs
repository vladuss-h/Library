using System;
namespace Library.App.Models
{/// Zakladna trieda pre entity v aplikacii. Dedíme z nej ostatné entity.
/// Sluzí na spolocne vlastnosti a splnenie poziadavky dedičnosti
    public abstract class BaseEntity 
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now; /// Datum vytvorenia záznamu
    }
}