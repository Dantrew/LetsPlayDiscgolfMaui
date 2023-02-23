using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Models
{
    internal class Player
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}
