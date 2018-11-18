using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskWebApplication.Models
{
    public class Quote
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string Name { get; set; }
        [Range(24, 96)]
        public int Width { get; set; }
        [Range(12, 48)]
        public int Depth { get; set; }
        [Range(0, 7)]
        [Display(Name = "Drawers")]
        public int NumOfDrawers { get; set; }
        public string Material { get; set; }
        [Display(Name = "Rush")]
        public int RushOrder { get; set; }
        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }
        [Display(Name = "Total")]
        public decimal TotalAmount { get; set; }

        public const int BASESIZE = 1001;
        public const int MIDDLESIZE = 2001;
        public const int BASEPRICE = 200;
        public const int OAKPRICE = 200;
        public const int LAMINATEPRICE = 100;
        public const int PINEPRICE = 50;
        public const int ROSEPRICE = 300;
        public const int VENEERPRICE = 125;

        public const int RUSHDAYS3 = 60;
        public const int RUSHDAYS5 = 40;
        public const int RUSHDAYS7 = 30;
        public enum MaterialList

        {
            Oak,
            Laminate,
            Pine,
            Rosewood,
            Veneer
        }

        public enum RushDays
        {

            rushday3 = 60,
            rushday5 = 40,
            rushday7 = 30


        }

        public int CONSTANT_MAXWIDTH = 96;
        public int CONSTANT_MINWIDTH = 24;
    }
}
