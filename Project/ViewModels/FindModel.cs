using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class FindModel
    {
        public bool CheckboxrRating1 { get; set; }
        public bool CheckboxrRating2 { get; set; }
        public bool CheckboxrRating3 { get; set; }
        public bool CheckboxrRating4 { get; set; }
        public bool CheckboxrRating5 { get; set; }

        [Display(Name = "янв.-мар.")]
        public bool CheckboxDate1 { get; set; }

        [Display(Name = "апр.-июн.")]
        public bool CheckboxDate2 { get; set; }

        [Display(Name = "июл.-сен.")]
        public bool CheckboxDate3 { get; set; }

        [Display(Name = "окт.-дек.")]
        public bool CheckboxDate4 { get; set; }

        public string textField { get; set; }
        public int Id { get; set; }
    }
}
